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

    public class ItemsListEditWindowViewModel<T> : ViewModelBase, IItemsListEditWindowViewModel<T> where T : IDisplayableModel, new()
    {
        public ItemsListViewModel<T> ItemsListViewModel { get; set; }

        public ItemsListEditWindowViewModel()
        {
            ItemsListViewModel = new ItemsListViewModel<T>();
            ItemsListViewModel.SetResult(new ItemsListData<T>
            {
                Items = new T[]
                {
                    new T {ItemCaption = "1"},
                    new T {ItemCaption = "1223232"},
                    new T {ItemCaption = "1fdsfdsfds"},
                },
                CurrentPageIndex = 1,
                PagesCount = 5
            });
            ItemsListViewModel.ItemListItemSelected += ItemListItemSelected;
            ItemsListViewModel.NewDataRequested += ItemsListNewDataRequested;
        }

        private void ItemsListNewDataRequested(ItemsListRequest request)
        {
            ItemsListViewModel.SetResult(new ItemsListData<T>
            {
                Items = new T[]
                {
                    new T {ItemCaption = "1 " + request.PageCurrentIndex},
                    new T {ItemCaption = "1223232 " + request.PageCurrentIndex},
                    new T {ItemCaption = "1fdsfdsfds " + request.PageCurrentIndex},
                },
                CurrentPageIndex = request.PageCurrentIndex,
                PagesCount = 5
            });
        }

        private void ItemListItemSelected(T item)
        {

        }
    }
}
