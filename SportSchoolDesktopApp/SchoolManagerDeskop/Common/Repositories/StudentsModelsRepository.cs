using SchoolManagerDeskop.Common.Extensions;
using SchoolManagerDeskop.Core.Repositories;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Repositories
{
    public interface IStudentsModelRepository : IPaginationSearchableRepository<StudentModel>
    {
    }

    public class StudentsModelsRepository : IStudentsModelRepository
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsModelsRepository(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
        }

        public PaginationResponse<StudentModel> GetPage(PaginationRequest request)
        {
            var response = _studentsRepository.GetPage(request);
            return new PaginationResponse<StudentModel>
            {
                Items = response.Items.Select(x => x.ToModel()).ToArray(),
                ItemsPerPage = response.ItemsPerPage,
                TotalItemsCount = response.TotalItemsCount,
                CurrentPageIndex = response.CurrentPageIndex,
            };
        }

        public PaginationResponse<StudentModel> GetPageWithSearch(SearchPaginationRequest request)
        {
            var response = _studentsRepository.GetPageWithSearch(request);
            return new PaginationResponse<StudentModel>
            {
                Items = response.Items.Select(x => x.ToModel()).ToArray(),
                ItemsPerPage = response.ItemsPerPage,
                TotalItemsCount = response.TotalItemsCount,
                CurrentPageIndex = response.CurrentPageIndex,
            };
        }

        public StudentModel[] Search(string searchString)
        {
            var response = _studentsRepository.Search(searchString);
            return response.Select(x => x.ToModel()).ToArray();
        }
    }
}
