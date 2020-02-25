using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AVcompanyWeb.Repositories;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public class UserRepository : BaseRepository<AVcompanydbEntities, User>, IUserRepository
    {
        public User GetSingle(int id)
        {
            throw new NotImplementedException();
        }
    }
}