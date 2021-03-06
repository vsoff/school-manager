﻿using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Services;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Common.ItemsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public class SelectEntityDialogViewModel<TEntity, TModel> : WindowViewModelBase, IDialogViewModel<object, TModel>
        where TEntity : Entity,
        new() where TModel : IDisplayableModel
    {
        private readonly IPaginationSearchableRepository<TEntity> _searchableRepository;
        private readonly IDialogsDisplayRegistry _dialogsDisplayRegistry;
        private readonly IModelMapper<TEntity, TModel> _entityMapper;
        private readonly IDisplayService _displayService;

        /// <summary>
        /// ViewModel списка сущностей.
        /// </summary>
        public ItemsListViewModel<TModel> ItemsListViewModel { get; set; }

        public object DialogArg { get; set; }

        public TModel DialogResult { get; private set; }

        public SelectEntityDialogViewModel(
            IPaginationSearchableRepository<TEntity> searchableRepository,
            IDialogsDisplayRegistry dialogsDisplayRegistry,
            IModelMapper<TEntity, TModel> entityMapper,
            IDisplayService displayService)
        {
            _dialogsDisplayRegistry = dialogsDisplayRegistry ?? throw new ArgumentNullException(nameof(dialogsDisplayRegistry));
            _searchableRepository = searchableRepository ?? throw new ArgumentNullException(nameof(searchableRepository));
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));
            _entityMapper = entityMapper ?? throw new ArgumentNullException(nameof(entityMapper));

            ItemsListViewModel = new ItemsListViewModel<TModel>();

            ApplyCommand = new RelayCommand(_ => CloseAction(ItemsListViewModel.SelectedItem));
            CancelCommand = new RelayCommand(_ => CloseAction(default(TModel)));
        }

        public override void OnOpen()
        {
            ItemsListViewModel.Clear();
            ItemsListViewModel.NewDataRequested += ItemsListUpdateData;
            ItemsListViewModel.GoToPage(0);
        }

        public override void OnClose()
        {
            ItemsListViewModel.NewDataRequested -= ItemsListUpdateData;
        }

        private void CloseAction(TModel model)
        {
            DialogResult = model;
            _displayService.Close((IDialogViewModel<object, TModel>)this);
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
        }

        public ICommand ApplyCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
