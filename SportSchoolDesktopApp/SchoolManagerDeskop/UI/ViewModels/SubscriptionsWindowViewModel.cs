using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Services;
using SchoolManagerDeskop.Common.Validators;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Common.ItemsList;
using SchoolManagerDeskop.UI.Enums;
using SchoolManagerDeskop.UI.Models;
using SchoolManagerDeskop.UI.ViewModels.EditWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public class SubscriptionsWindowViewModel : ItemsListEditWindowViewModel<Subscription, SubscriptionModel>
    {
        private readonly ISubscriptionsRepository _subscriptionsRepository;
        private readonly IDisplayService _displayService;

        public SubscriptionsWindowViewModel(
            IPaginationSearchableRepository<Subscription> searchableRepository,
            IModelMapper<Subscription, SubscriptionModel> entityMapper,
            IEntityValidator<SubscriptionModel> entityValidator,
            ISubscriptionsRepository subscriptionsRepository,
            IDisplayService displayService)
            : base(searchableRepository, entityMapper, entityValidator, displayService)
        {
            _subscriptionsRepository = subscriptionsRepository ?? throw new ArgumentNullException(nameof(subscriptionsRepository));
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));

            SelectGroupCommand = new RelayCommand(SelectGroupAction);
            SelectStudentCommand = new RelayCommand(SelectStudentAction);
        }

        internal override void ItemsListUpdateData(ItemsListRequest request)
        {
            var response = _subscriptionsRepository.GetPageByStudent(SelectedStudentId, new SearchPaginationRequest
            {
                SearchText = null,
                Limit = request.Take,
                PageIndex = request.PageIndex
            });

            ItemsListViewModel.SetResult(new ItemsListData<SubscriptionModel>
            {
                Items = response.Items.Select(entity => _entityMapper.ToModel(entity)).ToArray(),
                PagesCount = response.PagesCount,
                CurrentPageIndex = response.CurrentPageIndex
            });

            CurrentState = ItemsListEditState.NoSelected;
        }

        private void SelectGroupAction(object o)
        {
            GroupModel group = _displayService.ShowDialog<SelectEntityDialogViewModel<Group, GroupModel>, object, GroupModel>();
            if (group == null)
                return;

            Model.GroupId = group.Id;
            Model.GroupCaption = group.ItemCaption;
            Model.TrainerCaption = group.TrainerCaption;
        }

        private void SelectStudentAction(object o)
        {
            StudentModel student = _displayService.ShowDialog<SelectEntityDialogViewModel<Student, StudentModel>, object, StudentModel>();
            if (student == null)
                return;

            SelectedStudentId = student.Id;
            SelectedStudentCaption = student.ItemCaption;

            ItemsListViewModel.Refresh();
        }

        internal override void BeforeCreate()
        {
            Model.StudentId = SelectedStudentId;
            Model.BuyTime = DateTime.Now;
        }

        internal override void BeforeSave()
        {
            if (Model.HasUnlimitedGroup)
            {
                Model.GroupId = null;
            }

            if (Model.HasUnlimitedHours)
            {
                Model.SubHoursLeft = 0;
                Model.SubHoursMax = 0;
            }
        }

        private long _selectedStudentId;
        public long SelectedStudentId
        {
            get { return _selectedStudentId; }
            set
            {
                _selectedStudentId = value;
                OnPropertyChanged(nameof(SelectedStudentId));
            }
        }

        private string _selectedStudentCaption;
        public string SelectedStudentCaption
        {
            get { return _selectedStudentCaption; }
            set
            {
                _selectedStudentCaption = value;
                OnPropertyChanged(nameof(SelectedStudentCaption));
            }
        }

        public ICommand SelectGroupCommand { get; }
        public ICommand SelectStudentCommand { get; }
    }
}
