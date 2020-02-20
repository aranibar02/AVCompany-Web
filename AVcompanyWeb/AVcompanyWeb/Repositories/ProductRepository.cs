using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public class ProductRepository : BaseRepository<AVcompanydbEntities, Product>, IProductRepository
    {
        public Product GetSingle(int id)
        {
            throw new NotImplementedException();
        }
    }
}