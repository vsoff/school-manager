using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Common.ItemsList;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.ViewModels.EditWindows
{
    public enum ItemsListEditState : byte
    {
        NoSelected = 0,
        Selected = 1,
        Creating = 2,
        Editing = 3
    }

    public class ItemsListEditWindowViewModel<TEntity, TModel>
        : ViewModelBase where TEntity : Entity, new() where TModel : ValidatingModel, new()
    {

        private readonly IPaginationSearchableRepository<TEntity> _searchableRepository;
        private readonly IEntityMapper<TEntity, TModel> _entityMapper;

        /// <summary>
        /// ViewModel списка сущностей.
        /// </summary>
        public ItemsListViewModel<TModel> ItemsListViewModel { get; set; }

        /// <summary>
        /// ViewModel редактирования сущности.
        /// </summary>
        public EditorViewModel<TEntity, TModel> EditorViewModel { get; set; }

        public ItemsListEditWindowViewModel(IPaginationSearchableRepository<TEntity> searchableRepository,
            EditorViewModel<TEntity, TModel> editorViewModel,
            IEntityMapper<TEntity, TModel> entityMapper)
        {
            _searchableRepository = searchableRepository ?? throw new ArgumentNullException(nameof(searchableRepository));
            _entityMapper = entityMapper ?? throw new ArgumentNullException(nameof(entityMapper));

            EditorViewModel = editorViewModel;
            ItemsListViewModel = new ItemsListViewModel<TModel>();
            ItemsListViewModel.NewDataRequested += ItemsListUpdateData;
            ItemsListViewModel.ItemListItemSelected += ItemListItemSelected;
            ItemsListViewModel.GoToPage(0);

            ActionCommand = new RelayCommand(HandleAction, ActionWasExecute);
            CancelCommand = new RelayCommand(HandleCancel);

            CurrentState = ItemsListEditState.NoSelected;
        }

        /// <summary>
        /// Метод обрабатывающий запрос на обновление списка сущностей.
        /// </summary>
        private void ItemsListUpdateData(ItemsListRequest request)
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
            EditorViewModel.Model = item;
            CurrentState = ItemsListEditState.Selected;
        }

        private bool ActionWasExecute(object o)
        {
            return EditorViewModel.IsValid
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
                        EditorViewModel.Model = new TModel();
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
                        TModel model = EditorViewModel.Model;
                        _searchableRepository.Add(_entityMapper.ToCore(model));
                        ItemsListViewModel.Refresh();
                        CurrentState = ItemsListEditState.NoSelected;
                        break;
                    }
                case ItemsListEditState.Editing:
                    {
                        TModel model = EditorViewModel.Model;
                        _searchableRepository.Update(_entityMapper.ToCore(model));
                        ItemsListViewModel.Refresh();
                        CurrentState = ItemsListEditState.NoSelected;
                        break;
                    }
            }
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
                        MessageBox.Show("Закрытие окна");
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

        /// <summary>
        /// Текущий статус ViewModel.
        /// </summary>
        public ItemsListEditState CurrentState
        {
            get { return _currentState; }
            private set
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
    }
}
