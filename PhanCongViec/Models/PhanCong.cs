using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhanCongViec.Models
{
    public class PhanCong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPhanCong { get; set; }

        public string ngayGiao { get; set; }

        public string ngayHoanThanh { get; set; }

        public string tinhTrang { get; set; }

        public string danhGia { get; set; }

        public int idNguoiDung { get; set; }
        public int idCongViec { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
        public virtual CongViec CongViec { get; set; }
    }
}