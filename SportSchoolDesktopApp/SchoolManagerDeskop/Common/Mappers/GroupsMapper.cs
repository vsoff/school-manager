using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class GroupsMapper : IModelMapper<Group, GroupModel>
    {
        public Group ToCore(GroupModel obj) => new Group
        {
            Id = obj.Id,
            Name = obj.Name,
            Description = obj.Description,
            TrainerId = obj.TrainerId
        };

        public GroupModel ToModel(Group obj) => new GroupModel
        {
            Id = obj.Id,
            Name = obj.Name,
            Description = obj.Description,
            TrainerId = obj.TrainerId,
            TrainerCaption = obj.Trainer.FullName
        };
    }
}
