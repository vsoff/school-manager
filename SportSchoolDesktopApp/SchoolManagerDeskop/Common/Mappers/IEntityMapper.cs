using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public interface IModelMapper<TEntity, TModel>
    {
        TEntity ToCore(TModel obj);
        TModel ToModel(TEntity obj);
    }
}
