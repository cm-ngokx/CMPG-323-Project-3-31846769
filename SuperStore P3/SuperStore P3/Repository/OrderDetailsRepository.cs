//using static EcoPower_Logistics.Repository.IGenericRepository;
using System.Linq.Expressions;
using Data;
using System;
using System.Linq;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailsRepository
    {
        protected readonly SuperStoreContext _context;
        public OrderDetailsRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }
        public void Add(OrderDetail entity)
        {
            _context.Set<OrderDetail>().Add(entity);
        }
        public void AddRange(IEnumerable<OrderDetail> entities)
        {
            _context.Set<OrderDetail>().AddRange(entities);
        }
        public IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> expression)
        {
            return _context.Set<OrderDetail>().Where(expression);
        }
        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.Set<OrderDetail>().ToList();
        }
        public OrderDetail GetById(int id)
        {
            return _context.Set<OrderDetail>().Find(id);
        }
        public void Remove(OrderDetail entity)
        {
            _context.Set<OrderDetail>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<OrderDetail> entities)
        {
            _context.Set<OrderDetail>().RemoveRange(entities);
        }

        public void Update(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}


