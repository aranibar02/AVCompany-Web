using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    interface IPriceTypeRepository
    {
        IQueryable<PriceType> GetAll();
        IQueryable<PriceType> FindBy(Expression<Func<PriceType, bool>> predicate);
        void Add(PriceType entity);
        void Delete(PriceType entity);
        void Edit(PriceType entity);
        void Save();
    }
}
