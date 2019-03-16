using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Services;
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
        private readonly IDisplayService _displayService;

        public ScheduleListEditWindowViewModel(
            IPaginationSearchableRepository<ScheduleSubject> searchableRepository,
            IModelMapper<ScheduleSubject, ScheduleSubjectModel> entityMapper,
            IEntityValidator<ScheduleSubjectModel> entityValidator,
            IDisplayService displayService)
            : base(searchableRepository, entityMapper, entityValidator, displayService)
        {
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));

            SelectGroupCommand = new RelayCommand(SelectGroupAction);
        }

        private void SelectGroupAction(object o)
        {
            GroupModel group = _displayService.ShowDialog<SelectEntityDialogViewModel<Group, GroupModel>, object, GroupModel>();
            if (group == null)
                return;

            Model.GroupId = group.Id;
            Model.GroupCaption = group.ItemCaption;
        }

        public ICommand SelectGroupCommand { get; }
    }
}
