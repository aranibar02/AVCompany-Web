using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public interface IPriceProductRepository
    {
        IQueryable<PriceProduct> GetAll();
        PriceProduct GetSingle(int id);
        IQueryable<PriceProduct> FindBy(Expression<Func<PriceProduct, bool>> predicate);
        void Add(PriceProduct entity);
        void Delete(PriceProduct entity);
        void Edit(PriceProduct entity);
        void Save();
    }
}
