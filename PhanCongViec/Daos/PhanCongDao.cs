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

        public void Add(PhanCong phanCong)
        {
            myDb.PhanCongs.Add(phanCong);
            myDb.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = myDb.PhanCongs.FirstOrDefault(x => x.idPhanCong == id);
            myDb.PhanCongs.Remove(obj);
            myDb.SaveChanges();
        }

        public void Update(PhanCong phanCong)
        {
            var obj = myDb.PhanCongs.FirstOrDefault(x => x.idPhanCong == phanCong.idPhanCong);
            obj.idNguoiDung = phanCong.idNguoiDung;
            obj.idCongViec = phanCong.idCongViec;
            myDb.SaveChanges();
        }

        public void DanhGia(PhanCong phanCong)
        {
            var obj = myDb.PhanCongs.FirstOrDefault(x => x.idPhanCong == phanCong.idPhanCong);
            obj.danhGia = phanCong.danhGia;
            myDb.SaveChanges();
        }

        public void CapNhatTienDo(PhanCong phanCong)
        {
            var obj = myDb.PhanCongs.FirstOrDefault(x => x.idPhanCong == phanCong.idPhanCong);
            if (phanCong.tinhTrang == "Đang làm")
            {
                obj.tinhTrang = phanCong.tinhTrang;
            }else if(phanCong.tinhTrang == "Đã làm")
            {
                obj.tinhTrang = phanCong.tinhTrang;
                obj.ngayHoanThanh = DateTime.Now.ToString();
            }
            myDb.SaveChanges();
        }
    }
}