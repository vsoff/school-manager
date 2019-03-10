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
    public class GroupsListEditWindowViewModel : ItemsListEditWindowViewModel<Group, GroupModel>
    {
        private readonly IDialogsDisplayRegistry _dialogsDisplayRegistry;
        private readonly SelectEntityDialogViewModel<Trainer, TrainerModel> _trainerSelectDialogViewModel;
        public GroupsListEditWindowViewModel(
            IPaginationSearchableRepository<Group> searchableRepository,
            IEntityValidator<GroupModel> entityValidator,
            IModelMapper<Group, GroupModel> entityMapper,
            IDialogsDisplayRegistry dialogsDisplayRegistry,
            SelectEntityDialogViewModel<Trainer, TrainerModel> trainerSelectDialogViewModel)
            : base(searchableRepository, entityValidator, entityMapper)
        {
            _trainerSelectDialogViewModel = trainerSelectDialogViewModel ?? throw new ArgumentNullException(nameof(trainerSelectDialogViewModel));
            _dialogsDisplayRegistry = dialogsDisplayRegistry ?? throw new ArgumentNullException(nameof(dialogsDisplayRegistry));

            ChooseTrainerCommand = new RelayCommand(SelectTrainerAction);
        }

        private void SelectTrainerAction(object o)
        {
            TrainerModel trainer = _dialogsDisplayRegistry.ShowDialog(_trainerSelectDialogViewModel);
            if (trainer == null)
                return;

            Model.TrainerId = trainer.Id;
            Model.TrainerCaption = trainer.FullName;
        }

        public ICommand ChooseTrainerCommand { get; }
    }
}
