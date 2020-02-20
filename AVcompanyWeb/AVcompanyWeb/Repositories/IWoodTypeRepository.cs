using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public interface IWoodTypeRepository
    {
        IQueryable<WoodType> GetAll();
        IQueryable<WoodType> FindBy(Expression<Func<WoodType, bool>> predicate);
        void Add(WoodType entity);
        void Delete(WoodType entity);
        void Edit(WoodType entity);
        void Save();
    }
}
