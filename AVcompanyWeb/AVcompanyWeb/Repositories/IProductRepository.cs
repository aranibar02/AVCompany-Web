using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Product GetSingle(int id);
        IQueryable<Product> FindBy(Expression<Func<Product, bool>> predicate);
        void Add(Product entity);
        void Delete(Product entity);
        void Edit(Product entity);
        void Save();
    }
}
