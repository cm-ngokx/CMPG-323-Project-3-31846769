//using static EcoPower_Logistics.Repository.IGenericRepository;
using System.Linq.Expressions;
using Data;
using System;
using System.Linq;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository 
    {
        protected readonly SuperStoreContext _context;
        public OrdersRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }
        public void Add(Order entity)
        {
            _context.Set<Order>().Add(entity);
        }
        public void AddRange(IEnumerable<Order> entities)
        {
            _context.Set<Order>().AddRange(entities);
        }
        public IEnumerable<Order> Find(Expression<Func<Order, bool>> expression)
        {
            return _context.Set<Order>().Where(expression);
        }
        public IEnumerable<Order> GetAll()
        {
            return _context.Set<Order>().ToList();
        }
        public Order GetById(int id)
        {
            return _context.Set<Order>().Find(id);
        }
        public void Remove(Order entity)
        {
            _context.Set<Order>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<Order> entities)
        {
            _context.Set<Order>().RemoveRange(entities);
        }

        public void Update(Order entity)
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


