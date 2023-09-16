//using static EcoPower_Logistics.Repository.IGenericRepository;
using System.Linq.Expressions;
using Data;
using System;
using System.Linq;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductsRepository
    {
        protected readonly SuperStoreContext _context;
        public ProductRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }
        public void Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
        }
        public void AddRange(IEnumerable<Product> entities)
        {
            _context.Set<Product>().AddRange(entities);
        }
        public IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return _context.Set<Product>().Where(expression);
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }
        public Product GetById(int id)
        {
            return _context.Set<Product>().Find(id);
        }
        public void Remove(Product entity)
        {
            _context.Set<Product>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<Product> entities)
        {
            _context.Set<Product>().RemoveRange(entities);
        }

        public void Update(Product entity)
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


