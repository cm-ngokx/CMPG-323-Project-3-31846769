//using static EcoPower_Logistics.Repository.IGenericRepository;
using System.Linq.Expressions;
using Data;
using System;
using System.Linq;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class CustomersRepository: GenericRepository<Customer>, ICustomersRepository
    {
        protected readonly SuperStoreContext _context;
        public CustomersRepository(SuperStoreContext context):base(context)
        {
            _context = context;
        }
        public void Add(Customer entity)
        {
            _context.Set<Customer>().Add(entity);
        }
        public void AddRange(IEnumerable<Customer> entities)
        {
            _context.Set<Customer>().AddRange(entities);
        }
        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> expression)
        {
            return _context.Set<Customer>().Where(expression);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Set<Customer>().ToList();
        }
        public Customer GetById(int id)
        {
            return _context.Set<Customer>().Find(id);
        }
        public void Remove(Customer entity)
        {
            _context.Set<Customer>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<Customer> entities)
        {
            _context.Set<Customer>().RemoveRange(entities);
        }

        public void Update(Customer entity)
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


