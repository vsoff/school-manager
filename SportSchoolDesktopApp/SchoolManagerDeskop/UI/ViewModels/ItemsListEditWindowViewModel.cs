using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.ItemsList;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public interface IItemsListEditWindowViewModel<T> : IViewModel
    {
    }

    public class ItemsListEditWindowViewModel<T> : ViewModelBase, IItemsListEditWindowViewModel<T> where T : IDisplayableModel
    {
        private readonly IPaginationSearchableRepository<T> _searchableRepository;
        public ItemsListViewModel<T> ItemsListViewModel { get; set; }

        public ItemsListEditWindowViewModel(IPaginationSearchableRepository<T> searchableRepository)
        {
            _searchableRepository = searchableRepository ?? throw new ArgumentNullException(nameof(searchableRepository));

            ItemsListViewModel = new ItemsListViewModel<T>();
            ItemsListViewModel.NewDataRequested += ItemsListUpdateData;
            ItemsListViewModel.ItemListItemSelected += ItemListItemSelected;
            ItemsListViewModel.GoToPage(0);
        }

        private void ItemsListUpdateData(ItemsListRequest request)
        {
            var response = _searchableRepository.GetPage(new PaginationRequest
            {
                ItemsPerPage = request.Take,
                PageIndex = request.PageIndex
            });

            ItemsListViewModel.SetResult(new ItemsListData<T>
            {
                Items = response.Items,
                PagesCount = response.PagesCount,
                CurrentPageIndex = response.CurrentPageIndex
            });
        }

        private void ItemListItemSelected(T item)
        {

        }
    }
}
