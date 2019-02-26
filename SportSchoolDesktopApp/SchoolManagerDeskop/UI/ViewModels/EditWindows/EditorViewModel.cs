using SchoolManagerDeskop.Common.Validators;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.ViewModels.EditWindows
{
    public class EditorViewModel<TEntity, TModel> : ViewModelBase where TEntity : Entity, new() where TModel : ValidatingModel
    {
        private readonly IEntityValidator<TModel> _entityValidator;

        public EditorViewModel(IEntityValidator<TModel> entityValidator)
        {
            _entityValidator = entityValidator ?? throw new ArgumentNullException(nameof(entityValidator));
        }

        private void ValidateModel()
        {
            string[] warnings;
            _entityValidator.Validate(Model, out warnings);

            bool isValid = warnings.Length == 0;

            ErrorMessage = string.Join("\r\n", warnings.Select(x => $"*{x}"));
            IsValid = isValid;
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        private string _errorMessage;

        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }
        private bool _isValid;

        public TModel Model
        {
            get { return _model; }
            set
            {
                TModel clone = (TModel)value?.Clone();

                if (_model != null)
                    _model.ModelChanged -= ValidateModel;

                _model = clone;

                if (_model != null)
                {
                    _model.ModelChanged += ValidateModel;
                    ValidateModel();
                }

                OnPropertyChanged(nameof(Model));
            }
        }
        private TModel _model;
    }
}
