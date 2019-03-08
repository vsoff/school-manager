using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Validators;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Common.ItemsList;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.ViewModels.EditWindows
{
    public class ScheduleListEditWindowViewModel : ItemsListEditWindowViewModel<ScheduleSubject, ScheduleSubjectModel>
    {
        private readonly IDialogsDisplayRegistry _dialogsDisplayRegistry;
        private readonly SelectEntityDialogViewModel<Group, GroupModel> _groupSelectDialogViewModel;
        public ScheduleListEditWindowViewModel(
            IPaginationSearchableRepository<ScheduleSubject> searchableRepository,
            IEntityValidator<ScheduleSubjectModel> entityValidator,
            IModelMapper<ScheduleSubject, ScheduleSubjectModel> entityMapper,
            IDialogsDisplayRegistry dialogsDisplayRegistry,
            SelectEntityDialogViewModel<Group, GroupModel> groupSelectDialogViewModel)
            : base(searchableRepository, entityValidator, entityMapper)
        {
            _groupSelectDialogViewModel = groupSelectDialogViewModel ?? throw new ArgumentNullException(nameof(groupSelectDialogViewModel));
            _dialogsDisplayRegistry = dialogsDisplayRegistry ?? throw new ArgumentNullException(nameof(dialogsDisplayRegistry));

            ChooseGroupCommand = new RelayCommand(SelectGroupAction);
        }

        private void SelectGroupAction(object o)
        {
            GroupModel group = _dialogsDisplayRegistry.ShowDialog(_groupSelectDialogViewModel);
            if (group == null)
                return;

            Model.GroupId = group.Id;
            Model.GroupCaption = group.ItemCaption;
        }

        public ICommand ChooseGroupCommand { get; }
    }
}
