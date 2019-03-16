using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Services;
using SchoolManagerDeskop.Common.Validators;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Common.ItemsList;
using SchoolManagerDeskop.UI.Enums;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.ViewModels.EditWindows
{
    public class ItemsListEditWindowViewModel<TEntity, TModel>
        : WindowViewModelBase where TEntity : Entity, new() where TModel : ValidatingModel, new()
    {
        internal readonly IPaginationSearchableRepository<TEntity> _searchableRepository;
        internal readonly IModelMapper<TEntity, TModel> _entityMapper;
        internal readonly IEntityValidator<TModel> _entityValidator;
        private readonly IDisplayService _displayService;

        /// <summary>
        /// ViewModel списка сущностей.
        /// </summary>
        public ItemsListViewModel<TModel> ItemsListViewModel { get; set; }

        public ItemsListEditWindowViewModel(
            IPaginationSearchableRepository<TEntity> searchableRepository,
            IModelMapper<TEntity, TModel> entityMapper,
            IEntityValidator<TModel> entityValidator,
            IDisplayService displayService)
        {
            _searchableRepository = searchableRepository ?? throw new ArgumentNullException(nameof(searchableRepository));
            _entityValidator = entityValidator ?? throw new ArgumentNullException(nameof(entityValidator));
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));
            _entityMapper = entityMapper ?? throw new ArgumentNullException(nameof(entityMapper));

            ItemsListViewModel = new ItemsListViewModel<TModel>();

            ActionCommand = new RelayCommand(HandleAction, ActionWasExecute);
            CancelCommand = new RelayCommand(HandleCancel);

            CurrentState = ItemsListEditState.NoSelected;
        }

        public override void OnOpen()
        {
            ItemsListViewModel.NewDataRequested += ItemsListUpdateData;
            ItemsListViewModel.ItemListItemSelected += ItemListItemSelected;
            ItemsListViewModel.GoToPage(0);
        }

        public override void OnClose()
        {
            ItemsListViewModel.NewDataRequested -= ItemsListUpdateData;
            ItemsListViewModel.ItemListItemSelected -= ItemListItemSelected;
        }

        private void ValidateModel()
        {
            string[] warnings;
            _entityValidator.Validate(Model, out warnings);

            bool isValid = warnings.Length == 0;

            ErrorMessage = string.Join("\r\n", warnings.Select(x => $"*{x}"));
            IsValid = isValid;
        }

        /// <summary>
        /// Метод обрабатывающий запрос на обновление списка сущностей.
        /// </summary>
        internal virtual void ItemsListUpdateData(ItemsListRequest request)
        {
            var response = _searchableRepository.GetPage(new SearchPaginationRequest
            {
                SearchText = null,
                Limit = request.Take,
                PageIndex = request.PageIndex
            });

            ItemsListViewModel.SetResult(new ItemsListData<TModel>
            {
                Items = response.Items.Select(entity => _entityMapper.ToModel(entity)).ToArray(),
                PagesCount = response.PagesCount,
                CurrentPageIndex = response.CurrentPageIndex
            });

            CurrentState = ItemsListEditState.NoSelected;
        }

        /// <summary>
        /// Метод обрабатывающий новый выбранный элемент из списка.
        /// </summary>
        /// <param name="item">Выбранный элемент.</param>
        private void ItemListItemSelected(TModel item)
        {
            Model = item;
            CurrentState = ItemsListEditState.Selected;
        }

        private bool ActionWasExecute(object o)
        {
            return IsValid
                || CurrentState == ItemsListEditState.NoSelected
                || CurrentState == ItemsListEditState.Selected;
        }

        /// <summary>
        /// Обрабатывает событие, в зависимости от статуса ViewModel.
        /// </summary>
        private void HandleAction(object o)
        {
            switch (CurrentState)
            {
                case ItemsListEditState.NoSelected:
                    {
                        Model = new TModel();
                        CurrentState = ItemsListEditState.Creating;
                        break;
                    }
                case ItemsListEditState.Selected:
                    {
                        CurrentState = ItemsListEditState.Editing;
                        break;
                    }
                case ItemsListEditState.Creating:
                    {
                        BeforeCreate();
                        _searchableRepository.Add(_entityMapper.ToCore(Model));
                        ItemsListViewModel.Refresh();
                        CurrentState = ItemsListEditState.NoSelected;
                        break;
                    }
                case ItemsListEditState.Editing:
                    {
                        _searchableRepository.Update(_entityMapper.ToCore(Model));
                        ItemsListViewModel.Refresh();
                        CurrentState = ItemsListEditState.NoSelected;
                        break;
                    }
            }
        }

        /// <summary>
        /// Метод вызываемый перед записью нового экземпляра в БД.
        /// </summary>
        internal virtual void BeforeCreate()
        {
        }

        /// <summary>
        /// Обрабатывает отмену, в зависимости от статуса ViewModel.
        /// </summary>
        private void HandleCancel(object o)
        {
            switch (CurrentState)
            {
                case ItemsListEditState.NoSelected:
                    {
                        _displayService.Close(this);
                        break;
                    }
                default:
                    {
                        ItemsListViewModel.ResetSelection();
                        CurrentState = ItemsListEditState.NoSelected;
                        break;
                    }
            }
        }

        /// <summary>
        /// Обработчик события изменения статуса ViewModel.
        /// </summary>
        /// <param name="newState">Новый статус.</param>
        private void ViewModelStateChanged(ItemsListEditState newState)
        {
            switch (newState)
            {
                case ItemsListEditState.NoSelected:
                    {
                        ActionButtonCaption = "Создать";
                        CancelButtonCaption = "Закрыть";
                        break;
                    }
                case ItemsListEditState.Selected:
                    {
                        ActionButtonCaption = "Редактировать";
                        CancelButtonCaption = "Отмена";
                        break;
                    }
                case ItemsListEditState.Creating:
                    {
                        ActionButtonCaption = "Добавить";
                        CancelButtonCaption = "Отмена";
                        break;
                    }
                case ItemsListEditState.Editing:
                    {
                        ActionButtonCaption = "Сохранить";
                        CancelButtonCaption = "Отмена";
                        break;
                    }
            }
        }

        /// <summary>
        /// Команда вызываемая при вызове команды сохранить / добавить.
        /// </summary>
        public ICommand ActionCommand { get; }

        /// <summary>
        /// Команда вызываемая при вызове команды отмена / закрыть.
        /// </summary>
        public ICommand CancelCommand { get; }

        #region Properties

        /// <summary>
        /// Текущий статус ViewModel.
        /// </summary>
        public ItemsListEditState CurrentState
        {
            get { return _currentState; }
            internal set
            {
                _currentState = value;
                ViewModelStateChanged(value);
                OnPropertyChanged(nameof(CurrentState));
            }
        }
        private ItemsListEditState _currentState;

        public string ActionButtonCaption
        {
            get { return _actionButtonCaption; }
            private set
            {
                _actionButtonCaption = value;
                OnPropertyChanged(nameof(ActionButtonCaption));
            }
        }
        private string _actionButtonCaption;

        public string CancelButtonCaption
        {
            get { return _cancelButtonCaption; }
            private set
            {
                _cancelButtonCaption = value;
                OnPropertyChanged(nameof(CancelButtonCaption));
            }
        }
        private string _cancelButtonCaption;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        private string _errorMessage;

        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }
        private bool _isValid;

        public TModel Model
        {
            get { return _model; }
            set
            {
                TModel clone = (TModel)value?.Clone();

                if (_model != null)
                    _model.ModelChanged -= ValidateModel;

                _model = clone;

                if (_model != null)
                {
                    _model.ModelChanged += ValidateModel;
                    ValidateModel();
                }

                OnPropertyChanged(nameof(Model));
            }
        }
        private TModel _model;

        #endregion
    }
}
