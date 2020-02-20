using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public interface IUploadRepository 
    {
        IQueryable<Upload> GetAll();
        Upload GetSingle(int id);
        IQueryable<Upload> FindBy(Expression<Func<Upload, bool>> predicate);
        void Add(Upload entity);
        void Delete(Upload entity);
        void Edit(Upload entity);
        void Save();
    }
}
