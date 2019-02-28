using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Helpers;
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
    public interface IStudentsRepository : IPaginationSearchableRepository<Student>
    {
    }

    public class StudentsRepository : Repository<Student>, IStudentsRepository
    {

        public StudentsRepository(ISportEntitiesContextProvider sportEntitiesContextProvider)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));
        }

        public PaginationResponse<Student> GetPage(SearchPaginationRequest request)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return SearchRepositoryHelper<Student>.GetPageWithSearch(context.Students, request);
        }

        public PaginationResponse<Student> GetPageWithSearch(SearchPaginationRequest request)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return SearchRepositoryHelper<Student>.GetPageWithSearch(context.Students, request, StudentSearchExpression(request.SearchText));
        }

        private Expression<Func<Student, bool>> StudentSearchExpression(string searchText)
        {
            return x => x.FirstName.Contains(searchText)
                    || x.LastName.Contains(searchText)
                    || x.MiddleName.Contains(searchText);
        }

        //private Expression<Func<Student, bool>> StudentSearchExpressionHard(string searchText)
        //{
        //    string[] words;
        //    long[] numbers;
        //    SearchHelper.SplitSearchTextToTags(searchText, out words, out numbers);

        //    Expression multiExpression = null;

        //    foreach (var word in words)
        //    {
        //        Expression<Func<Student, bool>> partExpression =
        //            x => x.FirstName == word
        //            || x.LastName == word
        //            || x.MiddleName == word;
        //        multiExpression = multiExpression == null ? partExpression : Expression.Or(multiExpression, partExpression).Reduce();
        //    }

        //    foreach (var num in numbers)
        //    {
        //        Expression<Func<Student, bool>> partExpression =
        //            x => x.Id == num;
        //        multiExpression = multiExpression == null ? partExpression : Expression.Or(multiExpression, partExpression).Reduce();
        //    }

        //    return Expression.Lambda<Func<Student, bool>>(multiExpression);
        //}

    }
}
