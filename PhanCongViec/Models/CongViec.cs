using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhanCongViec.Models
{
    public class CongViec
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCongViec { get; set; }

        [StringLength(255)]
        [Required]
        public string tenCongViec { get; set; }

        public string moTa { get; set; }

        public virtual ICollection<PhanCong> PhanCongs { get; set; }
    }
}