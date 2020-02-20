using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public class PriceProductRepository : BaseRepository<AVcompanydbEntities, PriceProduct>, IPriceProductRepository
    {
        public PriceProduct GetSingle(int id)
        {
            throw new NotImplementedException();
        }
    }
}