using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories
{
    public interface ITrainersRepository : IRepository<Trainer>
    {
    }

    public class TrainersRepository : Repository<Trainer>, ITrainersRepository
    {
        public TrainersRepository(ISportEntitiesContextProvider sportEntitiesContextProvider)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));
        }

        internal override Expression<Func<Trainer, bool>>[] GetSearchExpression(string searchText) => new Expression<Func<Trainer, bool>>[]
        {
            x => x.FirstName.Contains(searchText)
                || x.LastName.Contains(searchText)
                || x.MiddleName.Contains(searchText)
        };
    }
}
