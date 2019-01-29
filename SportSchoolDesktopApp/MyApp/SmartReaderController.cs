using GemCard;
using SmartCardPlayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestSmartcard
{
    public enum SmartReaderType
    {
        Reader,
        Writer
    }

    public class SmartReaderController
    {
        private SmartReaderType Type { get; set; }
        public int WData { get; set; } = -1;
        private CardBase m_iCard = null;
        const string DefaultReader = "ACS ACR1281 1S Dual Reader PICC 0";
        // Делегат для выполнения задач вне объекта класса
        public delegate void OnInsertDelegate(int t);
        private OnInsertDelegate OnInsertCardPublic;

        public SmartReaderController(SmartReaderType Type, OnInsertDelegate PublicThings)
        {
            this.Type = Type;
            // инициализация основного контроллера
            m_iCard = new CardNative();
            // добавляем и запускаем слушателей
            m_iCard.OnCardInserted += new CardInsertedEventHandler(OnCardInserted);
            m_iCard.OnCardRemoved += new CardRemovedEventHandler(OnCardRemoved);
            m_iCard.StartCardEvents(DefaultReader);
            // выполняет внешние действия
            OnInsertCardPublic = PublicThings;
        }

        public void ChangeType(SmartReaderType Type)
        {
            this.Type = Type;
        }

        public void Dispose()
        {
            DestroyObject();
        }

        public void DestroyObject()
        {
            m_iCard.Disconnect(DISCONNECT.Unpower);

            m_iCard.StopCardEvents();
        }

        private void OnCardRemoved()
        {
            Console.WriteLine("Card removed");
        }

        private void OnCardInserted()
        {
            int data = -1;
            try
            {
                m_iCard.Connect(DefaultReader, SHARE.Shared, PROTOCOL.T0orT1);
                LoadKey();
                Authorize();
                switch (Type)
                {
                    case SmartReaderType.Reader:
                        data = ReadData();
                        break;
                    case SmartReaderType.Writer:
                        WriteData(WData);
                        data = WData;
                        break;
                }
                m_iCard.Disconnect(DISCONNECT.Leave);
            }
            catch (Exception ex)
            {
            }
            OnInsertCardPublic(data);
        }

        /// <summary>
        /// Загрузка ключа FFFFFFFFFFFF
        /// </summary>
        private void LoadKey()
        {
            byte[] data = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            APDUCommand apduCmd = new APDUCommand(0xFF, 0x82, 0x20, 0x00, data, 0x06);
            APDUResponse apduResp = m_iCard.Transmit(apduCmd);
        }

        /// <summary>
        /// Авторизация карты
        /// </summary>
        private void Authorize()
        {
            byte[] data = { 0x01, 0x00, 0x01, 0x60, 0x00 };
            APDUCommand apduCmd1 = new APDUCommand(0xFF, 0x86, 0x00, 0x00, data, 0x05);
            APDUResponse apduResp1 = m_iCard.Transmit(apduCmd1);
        }

        /// <summary>
        /// Считывает число из 4 байт карты
        /// </summary>
        private int ReadData()
        {
            APDUCommand apduCmd2 = new APDUCommand(0xFF, 0xb0, 0x00, 0x01, null, 0x10);
            APDUResponse apduResp2 = m_iCard.Transmit(apduCmd2);
            byte[] data = { apduResp2.Data[0], apduResp2.Data[1], apduResp2.Data[2], apduResp2.Data[3] };
            return BitConverter.ToInt32(data, 0);
        }

        /// <summary>
        /// Записывает число в 4 байта карты
        /// </summary>
        private void WriteData(int num)
        {
            byte[] numData = BitConverter.GetBytes(num);
            byte[] data = { numData[0], numData[1], numData[2], numData[3], 0x00, 0x00, 0x00, numData[0], numData[1], numData[2], 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            APDUCommand apduCmd4 = new APDUCommand(0xFF, 0xd6, 0x00, 0x01, data, 0x10);
            APDUResponse apduResp4 = m_iCard.Transmit(apduCmd4);
        }
    }
}
