using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

    public abstract class Repository<TEntity> : IRepository<TEntity>, IPaginationSearchableRepository<TEntity> where TEntity : Entity
    {
        internal ISportEntitiesContextProvider _sportEntitiesContextProvider;
        internal abstract Expression<Func<TEntity, bool>> GetSearchExpression(string searchText);
        internal virtual IQueryable<TEntity> GetObjectWithIncludes(DbContext context) => context.Set<TEntity>();

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
                return GetObjectWithIncludes(context).First(x => x.Id == entityId);
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

        public PaginationResponse<TEntity> GetPage(SearchPaginationRequest request)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return GetPageWithSearch(context, request);
        }

        public PaginationResponse<TEntity> GetPageWithSearch(SearchPaginationRequest request)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return GetPageWithSearch(context, request, GetSearchExpression(request.SearchText));
        }

        internal PaginationResponse<TEntity> GetPageWithSearch(DbContext context, SearchPaginationRequest request, Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> pageEntities = GetObjectWithIncludes(context)
                    .OrderBy(x => x.Id)
                    .Skip(request.Skip)
                    .Take(request.Limit);
            IQueryable<TEntity> allEntities = context.Set<TEntity>();

            if (expression != null)
            {
                pageEntities = pageEntities.Where(expression);
                allEntities = allEntities.Where(expression);
            }

            return new PaginationResponse<TEntity>
            {
                Items = pageEntities.ToArray(),
                TotalItemsCount = allEntities.Count(),
                Limit = request.Limit,
                CurrentPageIndex = request.PageIndex
            };
        }
    }
}
