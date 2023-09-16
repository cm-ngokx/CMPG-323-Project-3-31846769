using Models;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetail>
    {
        //OrderDetail GetMostRecentService();
        OrderDetail GetById(int id);
        IEnumerable<OrderDetail> GetAll();
        IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> expression);
        void Add(OrderDetail entity);
        void AddRange(IEnumerable<OrderDetail> entities);
        void Remove(OrderDetail entity);
        void RemoveRange(IEnumerable<OrderDetail> entities);
        void Update(OrderDetail entity);
    }

}


