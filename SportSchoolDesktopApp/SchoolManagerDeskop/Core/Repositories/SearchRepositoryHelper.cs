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
    public static class SearchRepositoryHelper<TEntity> where TEntity : Entity
    {
        public static PaginationResponse<TEntity> GetPageWithSearch(DbSet<TEntity> dbSet, SearchPaginationRequest request, Expression<Func<TEntity, bool>> expression = null)
        {
            int count;
            TEntity[] entities;
            if (expression == null)
            {
                entities = dbSet
                    .OrderBy(x => x.Id)
                    .Skip(request.Skip)
                    .Take(request.Limit)
                    .ToArray();
                count = dbSet.Count();
            }
            else
            {
                entities = dbSet
                    .Where(expression)
                    .OrderBy(x => x.Id)
                    .Skip(request.Skip)
                    .Take(request.Limit)
                    .ToArray();
                count = dbSet.Where(expression).Count();
            }

            return new PaginationResponse<TEntity>
            {
                Items = entities,
                TotalItemsCount = count,
                Limit = request.Limit,
                CurrentPageIndex = request.PageIndex
            };
        }

        private static void SplitSearchTextToTags(string searchText, out string[] words, out long[] numbers)
        {
            string[] rawWords = searchText.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            List<string> wordsTemp = new List<string>();
            List<long> numbersTemp = new List<long>();

            long searchNumber;
            foreach (string word in rawWords)
            {
                bool isNumber = long.TryParse(word, out searchNumber);
                if (!isNumber)
                    wordsTemp.Add(word);
                else
                    numbersTemp.Add(searchNumber);
            }

            words = wordsTemp.ToArray();
            numbers = numbersTemp.ToArray();
        }
    }
}
