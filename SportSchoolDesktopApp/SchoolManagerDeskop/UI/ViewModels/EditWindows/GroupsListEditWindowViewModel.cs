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
    public class GroupsListEditWindowViewModel : ItemsListEditWindowViewModel<Group, GroupModel>
    {
        private readonly IDisplayService _displayService;

        public GroupsListEditWindowViewModel(
            IPaginationSearchableRepository<Group> searchableRepository,
            IEntityValidator<GroupModel> entityValidator,
            IModelMapper<Group, GroupModel> entityMapper,
            IDisplayService displayService)
            : base(searchableRepository, entityMapper, entityValidator, displayService)
        {
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));

            SelectTrainerCommand = new RelayCommand(SelectTrainerAction);
        }

        private void SelectTrainerAction(object o)
        {
            TrainerModel trainer = _displayService.ShowDialog<SelectEntityDialogViewModel<Trainer, TrainerModel>, object, TrainerModel>();
            if (trainer == null)
                return;

            Model.TrainerId = trainer.Id;
            Model.TrainerCaption = trainer.FullName;
        }

        public ICommand SelectTrainerCommand { get; }
    }
}
