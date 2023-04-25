using PhanCongViec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanCongViec.Daos
{
    public class NguoiDungDao
    {
        DBPCCVContext myDb = new DBPCCVContext();
        public bool checkLogin(string email, string password)
        {
            var obj = myDb.NguoiDungs.FirstOrDefault(x => x.taiKhoan == email && x.matKhau == password);
            if (obj == null) { return false; }
            return true;
        }

        public NguoiDung getUserByEmail(string email)
        {
            return myDb.NguoiDungs.FirstOrDefault(x => x.taiKhoan.Equals(email));
        }


        public List<NguoiDung> getUser()
        {
            return myDb.NguoiDungs.ToList();
        }

        public void Add(NguoiDung user)
        {
            myDb.NguoiDungs.Add(user);
            myDb.SaveChanges();
        }
        public NguoiDung getById(int id)
        {
            return myDb.NguoiDungs.FirstOrDefault(x => x.idNguoiDung == id);
        }
        public void Update(NguoiDung user)
        {
            var obj = myDb.NguoiDungs.FirstOrDefault(x => x.idNguoiDung == user.idNguoiDung);
            obj.matKhau = user.matKhau;
            obj.hoTen = user.hoTen;
            obj.soDienThoai = user.soDienThoai;
            obj.email = user.email;
            obj.diaChi = user.diaChi;
            obj.idQuyen = user.idQuyen;
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.NguoiDungs.FirstOrDefault(x => x.idNguoiDung == id);
            myDb.NguoiDungs.Remove(obj);
            myDb.SaveChanges();
        }

        public List<PhanCong> getPhanCongByND(int id)
        {
            return myDb.PhanCongs.Where(x => x.idNguoiDung == id).ToList();
        }

        public bool checkExistEmail(string email)
        {
            var user = myDb.NguoiDungs.FirstOrDefault(x => x.taiKhoan == email);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}