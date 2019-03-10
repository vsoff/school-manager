using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class TrainersMapper : IModelMapper<Trainer, TrainerModel>
    {
        public Trainer ToCore(TrainerModel obj) => new Trainer
        {
            Id = obj.Id,
            FirstName = obj.FirstName,
            MiddleName = obj.MiddleName,
            LastName = obj.LastName
        };

        public TrainerModel ToModel(Trainer obj) => new TrainerModel
        {
            Id = obj.Id,
            FirstName = obj.FirstName,
            MiddleName = obj.MiddleName,
            LastName = obj.LastName
        };
    }
}
