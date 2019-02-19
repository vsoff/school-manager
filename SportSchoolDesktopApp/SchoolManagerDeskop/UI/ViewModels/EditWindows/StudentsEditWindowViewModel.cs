using SchoolManagerDeskop.Common.Extensions;
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

namespace SchoolManagerDeskop.UI.ViewModels.EditWindows
{
    public class StudentsEditWindowViewModel : ViewModelBase
    {
        public ItemsListViewModel<StudentModel> ItemsListViewModel { get; set; }
        internal IPaginationSearchableRepository<Student> _searchableRepository;

        public StudentsEditWindowViewModel(IPaginationSearchableRepository<Student> searchableRepository)
        {
            _searchableRepository = searchableRepository ?? throw new ArgumentNullException(nameof(searchableRepository));

            ItemsListViewModel = new ItemsListViewModel<StudentModel>();
            ItemsListViewModel.NewDataRequested += ItemsListUpdateData;
            ItemsListViewModel.ItemListItemSelected += ItemListItemSelected;
            ItemsListViewModel.GoToPage(0);
        }

        private void ItemsListUpdateData(ItemsListRequest request)
        {
            var response = _searchableRepository.GetPage(new PaginationRequest
            {
                Limit = request.Take,
                PageIndex = request.PageIndex
            });

            ItemsListViewModel.SetResult(new ItemsListData<StudentModel>
            {
                Items = response.Items.Select(x => x.ToModel()).ToArray(),
                PagesCount = response.PagesCount,
                CurrentPageIndex = response.CurrentPageIndex
            });
        }

        private void ItemListItemSelected(StudentModel item)
        {
        }
    }
}
