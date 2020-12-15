using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("QuanLyPhienBan", Schema = "nhutero5_utehy")]
    public partial class QuanLyPhienBan
    {
        [StringLength(20)]
        public string PhienBan { get; set; }
        public int? KichHoat { get; set; }
    }
}
