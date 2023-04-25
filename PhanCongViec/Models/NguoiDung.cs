using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhanCongViec.Models
{
    public class NguoiDung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idNguoiDung { get; set; }

        [StringLength(255)]
        [Required]
        public string taiKhoan { get; set; }

        [StringLength(255)]
        [Required]
        public string matKhau { get; set; }

        [StringLength(255)]
        [Required]
        public string hoTen { get; set; }

        [StringLength(255)]
        public string soDienThoai { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        public string diaChi { get; set; }

        public int idQuyen { get; set; }

        public virtual Quyen Quyen { get; set; }
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
    }
}