using SchoolManagerDeskop.Core.Dao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        long Add(TEntity entity);
        TEntity Get(long entityId);
        void Update(TEntity entity);
        void Delete(long entityId);
    }
}
