using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AVcompanyWeb.Models;

namespace AVcompanyWeb.Repositories
{
    public class UploadRepository : BaseRepository<AVcompanydbEntities, Upload>, IUploadRepository
    {
        public Upload GetSingle(int id)
        {
            throw new NotImplementedException();
        }
    }
}