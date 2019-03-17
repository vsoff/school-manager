using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class SubscriptionsMapper : IModelMapper<Subscription, SubscriptionModel>
    {
        public Subscription ToCore(SubscriptionModel obj)
        {
            if (!obj.BuyTime.HasValue || !obj.DateStart.HasValue || !obj.DateEnd.HasValue)
                throw new InvalidOperationException($"Поля {nameof(obj.BuyTime)}, {nameof(obj.DateStart)} и {nameof(obj.DateEnd)} должны быть заполнены");

            return new Subscription
            {
                Id = obj.Id,
                GroupId = obj.GroupId,
                BuyTime = obj.BuyTime.Value,
                DateEnd = obj.DateEnd.Value,
                StudentId = obj.StudentId,
                DateStart = obj.DateStart.Value,
                SubHoursMax = obj.SubHoursMax,
                HasUnlimitedGroup = obj.HasUnlimitedGroup,
                HasUnlimitedHours = obj.HasUnlimitedHours,
                SubHoursLeft = obj.SubHoursLeft
            };
        }

        public SubscriptionModel ToModel(Subscription obj) => new SubscriptionModel
        {
            Id = obj.Id,
            GroupId = obj.GroupId,
            BuyTime = obj.BuyTime,
            DateEnd = obj.DateEnd,
            StudentId = obj.StudentId,
            DateStart = obj.DateStart,
            SubHoursMax = obj.SubHoursMax,
            GroupCaption = obj.HasUnlimitedGroup ? string.Empty : $"[{obj.Group.Id}] {obj.Group.Name}",
            HasUnlimitedGroup = obj.HasUnlimitedGroup,
            HasUnlimitedHours = obj.HasUnlimitedHours,
            SubHoursLeft = obj.SubHoursLeft,
            TrainerCaption = obj.HasUnlimitedGroup ? string.Empty : $"[{obj.Group.Trainer.Id}] {obj.Group.Trainer.FullName}"
        };
    }
}
