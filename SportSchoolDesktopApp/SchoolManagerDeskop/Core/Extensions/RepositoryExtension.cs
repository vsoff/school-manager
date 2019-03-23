using SchoolManagerDeskop.Core.Dao.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Extensions
{
    public static class RepositoryExtension
    {
        /// <summary>
        /// Возвращает IQueryable<T> сущности с указанными includes и выражениями where.
        /// </summary>
        /// <typeparam name="TEntity">Класс сущности.</typeparam>
        /// <param name="context">Контекст БД.</param>
        /// <param name="includes">Все includes.</param>
        /// <param name="where">Все выражения where.</param>
        public static IQueryable<TEntity> Select<TEntity>(this DbContext context, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, bool>>[] where = null) where TEntity : Entity
        {
            IQueryable<TEntity> query = context.Set<TEntity>().Select(x => x);

            foreach (var include in includes ?? new Expression<Func<TEntity, object>>[0])
                query = query.Include(include);

            foreach (var expression in where ?? new Expression<Func<TEntity, bool>>[0])
                query = query.Where(expression);

            return query;
        }
    }
}
