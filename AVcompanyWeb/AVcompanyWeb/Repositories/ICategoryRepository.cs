using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;


namespace AVcompanyWeb.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        IQueryable<Category> FindBy(Expression<Func<Category, bool>> predicate);
        void Add(Category entity);
        void Delete(Category entity);
        void Edit(Category entity);
        void Save();
    }
}
