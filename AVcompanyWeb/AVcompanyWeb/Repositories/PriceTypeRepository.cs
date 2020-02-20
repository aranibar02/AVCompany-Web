using AVcompanyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVcompanyWeb.Repositories
{
    public class PriceTypeRepository : BaseRepository<AVcompanydbEntities, PriceType>, IPriceTypeRepository
    {
    }
}