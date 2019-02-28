using SchoolManagerDeskop.Core.Dao;
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

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        internal ISportEntitiesContextProvider _sportEntitiesContextProvider;

        public long Add(TEntity entity)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                TEntity temp = context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return temp.Id;
            }
        }

        public TEntity Get(long entityId)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return context.Set<TEntity>().Find(entityId);
        }

        public void Update(TEntity entity)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                var dbEntity = context.Set<TEntity>().Find(entity.Id);

                if (dbEntity != null)
                {
                    context.Entry(dbEntity).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(long entityId)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                var dbEntity = context.Set<TEntity>().Find(entityId);

                if (dbEntity != null)
                {
                    context.Set<TEntity>().Remove(dbEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
