using Models;
using System.Linq.Expressions;
using System.Collections.Generic;
using EcoPower_Logistics.Data;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        //Customer GetMostRecentService();
        Customer GetById(int id);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> Find(Expression<Func<Customer, bool>> expression);
        void Add(Customer entity);
        void AddRange(IEnumerable<Customer> entities);
        void Remove(Customer entity);
        void RemoveRange(IEnumerable<Customer> entities);
        void Update(Customer entity);

    }

}
