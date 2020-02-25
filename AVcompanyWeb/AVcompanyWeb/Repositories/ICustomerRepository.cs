using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;
using System.Linq.Expressions;

namespace AVcompanyWeb.Repositories
{
    interface ICustomerRepository
    {
        IQueryable<Customer> GetAll();
        IQueryable<Customer> FindBy(Expression<Func<Customer, bool>> predicate);
        void Add(Customer entity);
        void Delete(Customer entity);
        void Edit(Customer entity);
        void Save();
    }
}
