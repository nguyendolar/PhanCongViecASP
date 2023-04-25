using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhanCongViec.Models
{
    public class Quyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idQuyen { get; set; }

        [StringLength(255)]
        [Required]
        public string tenQuyen { get; set; }

        public virtual ICollection<NguoiDung> Users { get; set; }
    }
}