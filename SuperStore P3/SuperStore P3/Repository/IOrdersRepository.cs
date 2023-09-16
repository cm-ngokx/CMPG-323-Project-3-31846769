using Models;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace EcoPower_Logistics.Repository
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        //Order GetMostRecentService();
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> Find(Expression<Func<Order, bool>> expression);
        void Add(Order entity);
        void AddRange(IEnumerable<Order> entities);
        void Remove(Order entity);
        void RemoveRange(IEnumerable<Order> entities);
        void Update(Order entity);
    }

}

