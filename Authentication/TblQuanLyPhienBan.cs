using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblQuanLyPhienBan", Schema = "nhutero5_utehy")]
    public partial class TblQuanLyPhienBan
    {
        [StringLength(20)]
        public string PhienBan { get; set; }
        public int? KichHoat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayPhatHanh { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayDung { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
    }
}
