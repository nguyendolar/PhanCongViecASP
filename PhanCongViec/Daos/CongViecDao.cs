using PhanCongViec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanCongViec.Daos
{
    public class CongViecDao
    {
        DBPCCVContext myDb = new DBPCCVContext();
        public List<CongViec> getAll()
        {
            return myDb.CongViecs.ToList();
        }

        public void Add(CongViec congViec)
        {
            myDb.CongViecs.Add(congViec);
            myDb.SaveChanges();
        }
        public CongViec getById(int id)
        {
            return myDb.CongViecs.FirstOrDefault(x => x.idCongViec == id);
        }
        public void Update(CongViec congViec)
        {
            var obj = myDb.CongViecs.FirstOrDefault(x => x.idCongViec == congViec.idCongViec);
            obj.tenCongViec = congViec.tenCongViec;
            obj.moTa = congViec.moTa;
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.CongViecs.FirstOrDefault(x => x.idCongViec == id);
            myDb.CongViecs.Remove(obj);
            myDb.SaveChanges();
        }

        public List<PhanCong> getPhanCongByCV(int id)
        {
            return myDb.PhanCongs.Where(x => x.idCongViec == id).ToList();
        }
    }
}