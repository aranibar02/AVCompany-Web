using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public class ParameterRepository : BaseRepository<AVcompanydbEntities,Parameter>, IParameterRepository 
    {
    }
}