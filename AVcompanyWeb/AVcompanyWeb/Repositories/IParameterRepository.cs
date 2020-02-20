using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public interface IParameterRepository
    {
        IQueryable<Parameter> GetAll();
        IQueryable<Parameter> FindBy(Expression<Func<Parameter, bool>> predicate);
        void Add(Parameter entity);
        void Delete(Parameter entity);
        void Edit(Parameter entity);
        void Save();
    }
}
