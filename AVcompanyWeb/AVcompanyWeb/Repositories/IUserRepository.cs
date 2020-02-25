using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;
using System.Linq.Expressions;

namespace AVcompanyWeb.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetSingle(int id);
        IQueryable<User> FindBy(Expression<Func<User, bool>> predicate);
        void Add(User entity);
        void Delete(User entity);
        void Edit(User entity);
        void Save();
    }
}
