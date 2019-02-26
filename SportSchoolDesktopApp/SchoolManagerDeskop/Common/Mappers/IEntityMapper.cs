using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public interface IEntityMapper<TEntity, TModel> where TEntity : Entity, new() where TModel : IDisplayableModel
    {
        TEntity ToCore(TModel model);
        TModel ToModel(TEntity entity);
    }
}
