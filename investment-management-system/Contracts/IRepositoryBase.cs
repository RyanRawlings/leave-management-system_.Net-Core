using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace investment_management_system.Contracts
{
    //All classes should be able to perform these actions
    public interface IRepositoryBase<T> where T : class
    {
        //Any type of array of type T
        ICollection<T> FindAll();

        T FindById(int id);

        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        bool Save();

    }
}
