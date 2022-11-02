using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Houseseeker.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //get first or default value from table
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        //get all data from db
        IEnumerable<T> GetAll();

        //add data in db
        void Add(T entity);

        //remove data from db
        void Remove(T entity);

        //remove data in range from db
        void RemoveRange(IEnumerable<T> entities);
    }
}
