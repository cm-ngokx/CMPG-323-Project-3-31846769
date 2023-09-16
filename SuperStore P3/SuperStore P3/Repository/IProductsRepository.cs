using Models;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace EcoPower_Logistics.Repository
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        //Product GetMostRecentService();
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> Find(Expression<Func<Product, bool>> expression);
        void Add(Product entity);
        void AddRange(IEnumerable<Product> entities);
        void Remove(Product entity);
        void RemoveRange(IEnumerable<Product> entities);
        void Update(Product entity);
    }

}
