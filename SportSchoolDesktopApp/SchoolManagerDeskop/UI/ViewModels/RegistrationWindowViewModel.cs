using SchoolManagerDeskop.Common.Classes;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Services;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Common.ItemsList;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GemCard.Shell;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public class RegistrationWindowViewModel : WindowViewModelBase, IDialogViewModel<ScheduleSubjectModel, object>
    {
        #region Аргумент диалогового окна

        public ScheduleSubjectModel DialogArg
        {
            get => _dialogArg;
            set { _dialogArg = value; }
        }

        private ScheduleSubjectModel _dialogArg;
        public object DialogResult => null;

        #endregion

        private readonly IStudentsInSessionsRepository _studentsInSessionsRepository;
        private readonly IStudentRegistrationService _studentRegistrationService;
        private readonly IModelMapper<Student, StudentModel> _entityMapper;
        private readonly ICardStudentAuthoriser _cardStudentAuthoriser;
        private readonly IStudentsRepository _studentsRepository;
        private readonly IDateTimeService _dateTimeService;
        private readonly IDisplayService _displayService;

        public RegistrationModel Model { get; set; }

        private Session _currentSession;
        private long _selectedGroupId;

        /// <summary>
        /// ViewModel списка сущностей.
        /// </summary>
        public ItemsListViewModel<StudentModel> ItemsListViewModel { get; set; }

        public RegistrationWindowViewModel(
            IStudentsInSessionsRepository studentsInSessionsRepository,
            IStudentRegistrationService studentRegistrationService,
            IModelMapper<Student, StudentModel> entityMapper,
            ICardStudentAuthoriser cardStudentAuthoriser,
            IStudentsRepository studentsRepository,
            IDateTimeService dateTimeService,
            IDisplayService displayService)
        {
            _studentsInSessionsRepository = studentsInSessionsRepository ?? throw new ArgumentNullException(nameof(studentsInSessionsRepository));
            _studentRegistrationService = studentRegistrationService ?? throw new ArgumentNullException(nameof(studentRegistrationService));
            _studentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));
            _entityMapper = entityMapper ?? throw new ArgumentNullException(nameof(entityMapper));
            _cardStudentAuthoriser = cardStudentAuthoriser ?? throw new ArgumentNullException(nameof(cardStudentAuthoriser));

            ItemsListViewModel = new ItemsListViewModel<StudentModel>();

            Model = new RegistrationModel();
            _currentSession = null;

            SelectStudentCommand = new RelayCommand(SelectStudentAction);
            CancelCommand = new RelayCommand(CancelAction);
            RegistrationCommand = new RelayCommand(RegistrationAction);
        }

        public override void OnOpen()
        {
            // Подготовливаем данные.
            Model.StartTime = DialogArg.StartTime;
            Model.GroupCaption = DialogArg.GroupCaption;
            Model.TrainerCaption = DialogArg.TrainerCaption;
            _selectedGroupId = DialogArg.GroupId;

            // Получаем сессию, соответствующую по времени.
            DateTime sessionDateTime = _dateTimeService.GetCurrentTime().Date.Add(DialogArg.StartTime);
            _currentSession = _studentRegistrationService.GetGroupSession(_selectedGroupId, sessionDateTime);

            // Зануляем выбранного студента.
            SelectedStudent = null;

            // Настройка ItemsListViewModel.
            ItemsListViewModel.NewDataRequested += ItemsListUpdateData;
            ItemsListViewModel.ItemListItemSelected += ItemListItemSelected;
            ItemsListViewModel.GoToPage(0);

            // Подписываемся на события смарт-ридера.
            _cardStudentAuthoriser.CardInserted += CardInserted;
        }

        private void CardInserted(object sender, StudentCardEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show(e.ErrorMessage, "Ошибка");
                return;
            }

            SelectedStudent = _entityMapper.ToModel(e.Student);
        }

        public override void OnClose()
        {
            _cardStudentAuthoriser.CardInserted -= CardInserted;
            ItemsListViewModel.NewDataRequested -= ItemsListUpdateData;
            ItemsListViewModel.ItemListItemSelected -= ItemListItemSelected;
        }

        /// <summary>
        /// Метод обрабатывающий запрос на обновление списка студентов.
        /// </summary>
        internal virtual void ItemsListUpdateData(ItemsListRequest request)
        {
            var response = _studentsInSessionsRepository.GetStudentsInSessionPage(_currentSession.Id,
                new SearchPaginationRequest
                {
                    SearchText = null,
                    Limit = request.Take,
                    PageIndex = request.PageIndex
                });

            ItemsListViewModel.SetResult(new ItemsListData<StudentModel>
            {
                Items = response.Items.Select(entity => _entityMapper.ToModel(entity.Student)).ToArray(),
                PagesCount = response.PagesCount,
                CurrentPageIndex = response.CurrentPageIndex
            });
        }

        /// <summary>
        /// Метод обрабатывающий новый выбранный элемент из списка студентов.
        /// </summary>
        private void ItemListItemSelected(StudentModel item) => SelectedStudent = item;

        private void SelectStudentAction(object o)
        {
            StudentModel student = _displayService.ShowDialog<SelectEntityDialogViewModel<Student, StudentModel>, object, StudentModel>();
            if (student == null)
                return;

            ItemsListViewModel.ResetSelection();
            SelectedStudent = student;
        }

        private void CancelAction(object o)
        {
            if (SelectedStudent == null)
                _displayService.Close((IDialogViewModel<ScheduleSubjectModel, object>) this);
            else
                ItemsListViewModel.ResetSelection();
        }

        private void RegistrationAction(object o)
        {
            RegistrationInfoResponse regInfo = _studentRegistrationService
                .GetRegistrationInfo(SelectedStudent.Id, _currentSession.Id, _dateTimeService.GetCurrentTime());

            if (regInfo.IsRegistrationPossible)
            {
                _studentRegistrationService.RegisterStudentInSession(SelectedStudent.Id, _currentSession.Id);
                UpdateRegistrationPossibility();
            }
            else if (regInfo.IsCanUnregister)
            {
                _studentRegistrationService.UnregisterStudentInSession(SelectedStudent.Id, _currentSession.Id);
                UpdateRegistrationPossibility();
            }

            ItemsListViewModel.Refresh();
        }

        private void UpdateRegistrationPossibility()
        {
            StudentModel student = SelectedStudent;

            if (student == null)
                return;

            RegistrationInfoResponse regInfo = _studentRegistrationService
                .GetRegistrationInfo(student.Id, _currentSession.Id, _dateTimeService.GetCurrentTime());

            // Проверяем, зарегистрирован ли уже ученик.
            if (regInfo.IsAlreadyRegistered)
            {
                Model.SubscriptionActivityText = $"Ученик зарегистрирован";
                Model.IsSubscribeButtonActive = regInfo.IsCanUnregister;
                Model.SubscribeButtonText = "Убрать отметку";
                Model.IsMessageWithoutWarning = true;
            }
            else
            {
                // Проверяем, возможна ли регистрация.
                Model.SubscriptionActivityText = regInfo.IsRegistrationPossible
                    ? $"Регистрация возможна\n({(regInfo.Subscription.HasUnlimitedGroup ? "Безлимитный" : "Лимитированный")} абонемент)"
                    : $"Регистрация невозможна!\n\n{regInfo.WarningMessage}";
                Model.IsSubscribeButtonActive = regInfo.IsRegistrationPossible;
                Model.IsMessageWithoutWarning = regInfo.IsRegistrationPossible;
                Model.SubscribeButtonText = "Зарегистрировать ученика";
            }
        }

        public void SelectedStudentChanged(StudentModel student)
        {
            Model.CancelButtonText = student == null ? "Закрыть" : "Отмена";
            UpdateRegistrationPossibility();
        }

        private StudentModel _selectedStudent;

        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
                SelectedStudentChanged(value);
            }
        }

        public ICommand SelectStudentCommand { get; }
        public ICommand RegistrationCommand { get; }
        public ICommand CancelCommand { get; }
    }
}