using System;

namespace GemCard.Shell
{
    public class SmartReaderListener : ISmartReaderListener
    {
        const string DefaultReader = "ACS ACR1281 1S Dual Reader PICC 0";

        public event EventHandler<CardInsertedEventArgs> CardInserted;
        public event EventHandler<EventArgs> CardRemoved;

        private bool _isCardHere;
        private string _selectedReader;
        private readonly CardBase _card;
        private readonly object _syncLocker;

        public SmartReaderListener(string reader = DefaultReader)
        {
            _syncLocker = new object();
            _isCardHere = false;
            _selectedReader = reader;
            _card = new CardNative();
            _card.OnCardInserted += OnCardInserted;
            _card.OnCardRemoved += OnCardRemoved;
            _card.StartCardEvents(_selectedReader);
        }

        private void OnCardRemoved()
        {
            lock (_syncLocker)
            {
                _isCardHere = false;
                CardRemoved?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnCardInserted()
        {
            lock (_syncLocker)
            {
                _isCardHere = true;
                var value = TryInvokeCardAction(ReadData);
                CardInserted?.Invoke(this, new CardInsertedEventArgs { Value = value });
            }
        }

        public bool WriteValue(int value)
        {
            lock (_syncLocker)
            {
                if (!_isCardHere)
                    return false;

                // Пытаемся записать значение.
                if (TryInvokeCardAction(() => WriteData(value)) == null)
                    return false;

                // Проверяем, записалось ли значение.
                var cardValue = TryInvokeCardAction(ReadData);
                return cardValue == value;
            }
        }

        public void ChangeReader(string reader)
        {
            lock (_syncLocker)
            {
                _selectedReader = reader;
                _card.StopCardEvents();
                _card.StartCardEvents(_selectedReader);
            }
        }

        private int? TryInvokeCardAction(Func<int> action)
        {
            int? data = null;

            try
            {
                _card.Connect(_selectedReader, SHARE.Shared, PROTOCOL.T0orT1);
                LoadKey();
                Authorize();
                data = action.Invoke();
                _card.Disconnect(DISCONNECT.Leave);
            }
            catch (Exception ex)
            {
            }

            return data;
        }

        #region CardActions

        /// <summary>
        /// Загрузка ключа FFFFFFFFFFFF
        /// </summary>
        private void LoadKey()
        {
            byte[] data = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            APDUCommand apduCmd = new APDUCommand(0xFF, 0x82, 0x20, 0x00, data, 0x06);
            APDUResponse apduResp = _card.Transmit(apduCmd);
        }

        /// <summary>
        /// Авторизация карты
        /// </summary>
        private void Authorize()
        {
            byte[] data = { 0x01, 0x00, 0x01, 0x60, 0x00 };
            APDUCommand apduCmd1 = new APDUCommand(0xFF, 0x86, 0x00, 0x00, data, 0x05);
            APDUResponse apduResp1 = _card.Transmit(apduCmd1);
        }

        /// <summary>
        /// Считывает число из 4 байт карты
        /// </summary>
        private int ReadData()
        {
            APDUCommand apduCmd2 = new APDUCommand(0xFF, 0xb0, 0x00, 0x01, null, 0x10);
            APDUResponse apduResp2 = _card.Transmit(apduCmd2);
            byte[] data = { apduResp2.Data[0], apduResp2.Data[1], apduResp2.Data[2], apduResp2.Data[3] };
            return BitConverter.ToInt32(data, 0);
        }

        /// <summary>
        /// Записывает число в 4 байта карты
        /// </summary>
        private int WriteData(int num)
        {
            byte[] numData = BitConverter.GetBytes(num);
            byte[] data =
            {
                numData[0], numData[1], numData[2], numData[3], 0x00, 0x00, 0x00, numData[0], numData[1], numData[2],
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };
            APDUCommand apduCmd4 = new APDUCommand(0xFF, 0xd6, 0x00, 0x01, data, 0x10);
            APDUResponse apduResp4 = _card.Transmit(apduCmd4);

            return num;
        }

        #endregion

        public void Dispose()
        {
            _card.OnCardInserted -= OnCardInserted;
            _card.OnCardRemoved -= OnCardRemoved;
            _card.Disconnect(DISCONNECT.Unpower);
            _card.StopCardEvents();
        }
    }
}