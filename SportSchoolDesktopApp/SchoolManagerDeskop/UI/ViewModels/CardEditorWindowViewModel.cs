using System;
using System.Windows;
using System.Windows.Input;
using GemCard.Shell;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Services;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Models;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public class CardEditorWindowViewModel : WindowViewModelBase
    {
        private readonly IModelMapper<Student, StudentModel> _studentMapper;
        private readonly ICardStudentAuthoriser _cardStudentAuthoriser;
        private readonly IDisplayService _displayService;

        public CardEditorWindowViewModel(
            IModelMapper<Student, StudentModel> studentMapper,
            ICardStudentAuthoriser cardStudentAuthoriser,
            IDisplayService displayService)
        {
            _studentMapper = studentMapper ?? throw new ArgumentNullException(nameof(studentMapper));
            _cardStudentAuthoriser = cardStudentAuthoriser ?? throw new ArgumentNullException(nameof(cardStudentAuthoriser));
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));

            CardClearWriteCommand = new RelayCommand(_ =>
            {
                bool result = _cardStudentAuthoriser.UnbindCard();

                if (result)
                {
                    CardInfoMessage = "<Данные с карты удалены>";
                }
                else
                {
                    MessageBox.Show("Неудача стирания значения", "Результат операции");
                }
            });
            CardWriteCommand = new RelayCommand(_ =>
            {
                if (SelectedStudentId == null)
                {
                    MessageBox.Show("Сначала необходимо выбрать ученика", "Ошибка");
                }
                else
                {
                    bool result = _cardStudentAuthoriser.BindCard((int) SelectedStudentId);

                    if (result)
                    {
                        CardInfoMessage = SelectedStudentCaption;
                        SelectedStudentId = null;
                        SelectedStudentCaption = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Неудача записи, попробуйте ещё раз", "Ошибка");
                    }
                }
            });
            CloseCommand = new RelayCommand(_ => _displayService.Close(this));
            SelectStudentCommand = new RelayCommand(SelectStudentAction);
        }

        private void SelectStudentAction(object o)
        {
            StudentModel student = _displayService.ShowDialog<SelectEntityDialogViewModel<Student, StudentModel>, object, StudentModel>();
            if (student == null)
                return;

            SelectedStudentId = student.Id;
            SelectedStudentCaption = student.ItemCaption;
        }

        public ICommand SelectStudentCommand { get; }

        private void CardInserted(object sender, StudentCardEventArgs e)
        {
            IsCardHere = true;

            CardInfoMessage = e.IsSuccess
                ? _studentMapper.ToModel(e.Student).ItemCaption
                : $"<{e.ErrorMessage}>";
        }

        private void CardRemoved(object sender, EventArgs e)
        {
            IsCardHere = false;
            CardInfoMessage = string.Empty;
        }

        public override void OnOpen()
        {
            base.OnOpen();

            IsCardHere = false;
            CardInfoMessage = string.Empty;
            SelectedStudentId = null;
            SelectedStudentCaption = string.Empty;

            _cardStudentAuthoriser.CardInserted += CardInserted;
            _cardStudentAuthoriser.CardRemoved += CardRemoved;
        }

        public override void OnClose()
        {
            base.OnClose();

            _cardStudentAuthoriser.CardInserted -= CardInserted;
            _cardStudentAuthoriser.CardRemoved -= CardRemoved;
        }

        #region Props

        public bool IsCardHere
        {
            get => _isCardHere;
            set
            {
                _isCardHere = value;
                OnPropertyChanged(nameof(IsCardHere));
            }
        }

        private bool _isCardHere;

        public string CardInfoMessage
        {
            get => _cardInfoMessage;
            set
            {
                _cardInfoMessage = value;
                OnPropertyChanged(nameof(CardInfoMessage));
            }
        }

        private string _cardInfoMessage;

        public long? SelectedStudentId
        {
            get => _selectedStudentId;
            set
            {
                _selectedStudentId = value;
                OnPropertyChanged(nameof(SelectedStudentId));
            }
        }

        private long? _selectedStudentId;

        public string SelectedStudentCaption
        {
            get => _selectedStudentCaption;
            set
            {
                _selectedStudentCaption = value;
                OnPropertyChanged(nameof(SelectedStudentCaption));
            }
        }

        private string _selectedStudentCaption;

        #endregion

        public ICommand CardWriteCommand { get; }
        public ICommand CardClearWriteCommand { get; }
        public ICommand CloseCommand { get; }
    }
}