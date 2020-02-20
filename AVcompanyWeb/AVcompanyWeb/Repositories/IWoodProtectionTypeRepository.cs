using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public interface IWoodProtectionTypeRepository
    {
        IQueryable<WoodProtectionType> GetAll();
        IQueryable<WoodProtectionType> FindBy(Expression<Func<WoodProtectionType, bool>> predicate);
        void Add(WoodProtectionType entity);
        void Delete(WoodProtectionType entity);
        void Edit(WoodProtectionType entity);
        void Save();
    }
}
