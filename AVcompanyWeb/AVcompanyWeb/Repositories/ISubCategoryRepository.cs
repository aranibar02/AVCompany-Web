using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public interface ISubCategoryRepository
    {
        IQueryable<SubCategory> GetAll();
        IQueryable<SubCategory> FindBy(Expression<Func<SubCategory, bool>> predicate);
        void Add(SubCategory entity);
        void Delete(SubCategory entity);
        void Edit(SubCategory entity);
        void Save();
    }
}
