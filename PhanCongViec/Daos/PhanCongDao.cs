using PhanCongViec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanCongViec.Daos
{
    public class PhanCongDao
    {
        DBPCCVContext myDb = new DBPCCVContext();
        public List<PhanCong> getAll()
        {
            return myDb.PhanCongs.OrderByDescending(x => x.idPhanCong).ToList();
        }
    }
}