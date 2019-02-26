using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Helpers;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories
{
    public interface IStudentsRepository : IPaginationSearchableRepository<Student>
    {
    }

    public class StudentsRepository : IStudentsRepository
    {
        private readonly ISportEntitiesContextProvider _sportEntitiesContextProvider;

        public StudentsRepository(ISportEntitiesContextProvider sportEntitiesContextProvider)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));
        }

        public PaginationResponse<Student> GetPage(PaginationRequest request)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                var data = context.Students
                   .OrderBy(x => x.Id)
                   .Skip(request.Skip)
                   .Take(request.Limit)
                   .ToArray();

                var count = context.Students.Count();

                return new PaginationResponse<Student>
                {
                    Items = data,
                    TotalItemsCount = count,
                    Limit = request.Limit,
                    CurrentPageIndex = request.PageIndex
                };
            }
        }

        public Student[] Search(string searchText)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return context.Students
                    .Where(StudentSearchExpression(searchText))
                    .ToArray();
        }

        public PaginationResponse<Student> GetPageWithSearch(SearchPaginationRequest request)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                var expression = StudentSearchExpression(request.SearchText);

                var data = context.Students
                    .Where(expression)
                    .OrderBy(x => x.Id)
                    .Skip(request.Pagination.Skip)
                    .Take(request.Pagination.Limit)
                    .ToArray();

                var count = context.Students.Where(expression).Count();

                return new PaginationResponse<Student>
                {
                    Items = data,
                    TotalItemsCount = count,
                    Limit = request.Pagination.Limit,
                    CurrentPageIndex = request.Pagination.PageIndex
                };
            }
        }

        private Expression<Func<Student, bool>> StudentSearchExpression(string searchText)
        {
            return x => x.FirstName.Contains(searchText)
                    || x.LastName.Contains(searchText)
                    || x.MiddleName.Contains(searchText);
        }

        private Expression<Func<Student, bool>> StudentSearchExpressionHard(string searchText)
        {
            string[] words;
            long[] numbers;
            SearchHelper.SplitSearchTextToTags(searchText, out words, out numbers);

            Expression multiExpression = null;

            foreach (var word in words)
            {
                Expression<Func<Student, bool>> partExpression =
                    x => x.FirstName == word
                    || x.LastName == word
                    || x.MiddleName == word;
                multiExpression = multiExpression == null ? partExpression : Expression.Or(multiExpression, partExpression).Reduce();
            }

            foreach (var num in numbers)
            {
                Expression<Func<Student, bool>> partExpression =
                    x => x.Id == num;
                multiExpression = multiExpression == null ? partExpression : Expression.Or(multiExpression, partExpression).Reduce();
            }

            return Expression.Lambda<Func<Student, bool>>(multiExpression);
        }

        public long Add(Student entity)
        {
            Student temp;
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                temp = context.Students.Add(entity);
                context.SaveChanges();
            }
            return temp.Id;
        }

        public Student Get(long entityId)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return context.Students.Find(entityId);
        }

        public void Update(Student entity)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                var dbEntity = context.Students.Find(entity.Id);

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
                var dbEntity = context.Students.Find(entityId);

                if (dbEntity != null)
                {
                    context.Students.Remove(dbEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
