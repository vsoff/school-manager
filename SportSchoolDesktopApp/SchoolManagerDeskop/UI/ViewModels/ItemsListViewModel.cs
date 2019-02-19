using SchoolManagerDeskop.Properties;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Common.ItemsList;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.ViewModels
{
    /// <summary>
    /// Предоставляет метод, обрабатывающий событие, возникающее при смене выбранного элемента из списка.
    /// </summary>
    /// <param name="item">Выбранный элемент.</param>
    public delegate void ItemsListItemSelectedEventHandler<T>(T item) where T : IDisplayableModel;

    /// <summary>
    /// Предоставляет метод, обрабатывающий событие, возникающее при необходимости обновления данных в списке.
    /// </summary>
    /// <param name="request">Объект запроса новых данных.</param>
    public delegate void ItemsListItemSelectedEventHandler(ItemsListRequest request);

    public class ItemsListViewModel<T> : ViewModelBase where T : IDisplayableModel
    {
        public int[] LimitsList { get; }
        public ObservableCollection<T> Items { get; set; }

        public ItemsListViewModel()
        {
            Items = new ObservableCollection<T>();
            LimitsList = new int[] { 4, 10, 25, 50, 100 };
            Limit = LimitsList.First();

            FirstPageCommand = new RelayCommand(o => GoToPage(0), o => CurrentPageIndex > 0);
            PrevPageCommand = new RelayCommand(o => GoToPage(CurrentPageIndex - 1), o => CurrentPageIndex > 0);
            NextPageCommand = new RelayCommand(o => GoToPage(CurrentPageIndex + 1), o => CurrentPageIndex < PagesCount - 1);
            LastPageCommand = new RelayCommand(o => GoToPage(PagesCount - 1), o => CurrentPageIndex < PagesCount - 1);
            ItemLeftDoubleClick = new RelayCommand(o => { ItemListItemSelected?.Invoke((T)o); });
        }

        /// <summary>
        /// Передаёт данные, которые должны быть установлены для этой ViewModel.
        /// </summary>
        /// <param name="data">Данные списка.</param>
        public void SetResult(ItemsListData<T> data)
        {
            Items.Clear();
            foreach (var model in data.Items)
                Items.Add(model);

            PagesCount = data.PagesCount;
            CurrentPageIndex = data.CurrentPageIndex;
        }

        /// <summary>
        /// Осуществляет переход на указанную страницу.
        /// </summary>
        /// <param name="pageIndex">Индекс страницы.</param>
        public void GoToPage(int pageIndex)
        {
            NewDataRequested?.Invoke(new ItemsListRequest
            {
                Take = Limit,
                PageIndex = pageIndex
            });
        }

        /// <summary>
        /// Метод вызывается при изменении количества выводимых элементов на странице.
        /// </summary>
        /// <param name="pageIndex">Индекс страницы.</param>
        private void ItemsPerPageChanged(int newItemsPerPage)
        {
            NewDataRequested?.Invoke(new ItemsListRequest
            {
                Take = newItemsPerPage,
                PageIndex = 0
            });
        }

        #region Events

        /// <summary>
        /// Событие возникающее при выборе элемента списка.
        /// </summary>
        public event ItemsListItemSelectedEventHandler<T> ItemListItemSelected;

        /// <summary>
        /// Событие возникающее при необходимости обновления данных в списке.
        /// </summary>
        public event ItemsListItemSelectedEventHandler NewDataRequested;

        #endregion

        #region Properties

        /// <summary>
        /// Выбранный элемент списка.
        /// </summary>
        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        private T _selectedItem;

        /// <summary>
        /// Строка, отображающая номер текущей страницы.
        /// </summary>
        public string CurrentPageText
        {
            get
            {
                return PagesCount == 0 ? Resources.ItemsList_PaginationEmptyCaption
                    : string.Format(Resources.ItemsList_PaginationCaption, CurrentPageIndex + 1, PagesCount);
            }
        }

        /// <summary>
        /// Страниц всего.
        /// </summary>
        public int PagesCount
        {
            get { return _pagesCount; }
            set
            {
                _pagesCount = value;
                OnPropertyChanged(nameof(PagesCount));
                OnPropertyChanged(nameof(CurrentPageText));
            }
        }
        private int _pagesCount;

        /// <summary>
        /// Индекс текущей страницы.
        /// </summary>
        public int CurrentPageIndex
        {
            get { return _pageCurrentIndex; }
            set
            {
                _pageCurrentIndex = value;
                OnPropertyChanged(nameof(CurrentPageIndex));
                OnPropertyChanged(nameof(CurrentPageText));
            }
        }
        private int _pageCurrentIndex;

        /// <summary>
        /// Количество выводимых элементов на странице.
        /// </summary>
        public int Limit
        {
            get { return _limit; }
            set
            {
                _limit = value;
                OnPropertyChanged(nameof(Limit));
                ItemsPerPageChanged(value);
            }
        }
        private int _limit;

        #endregion

        #region Commands

        public ICommand FirstPageCommand { get; }
        public ICommand PrevPageCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand LastPageCommand { get; }
        public ICommand ItemLeftDoubleClick { get; }

        #endregion
    }
}
