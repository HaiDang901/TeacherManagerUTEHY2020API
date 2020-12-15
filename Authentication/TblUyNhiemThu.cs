using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblUyNhiemThu")]
    public partial class TblUyNhiemThu
    {
        [Key]
        [Column("MaUNT")]
        public long MaUnt { get; set; }
        [StringLength(10)]
        public string MaKhoanThu { get; set; }
        [StringLength(10)]
        public string MaNganHang { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BatDau { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KetThuc { get; set; }
        public int? KichHoat { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        [StringLength(50)]
        public string NguoiTao { get; set; }
        [Column("DP1", TypeName = "ntext")]
        public string Dp1 { get; set; }
        [Column("DP2", TypeName = "ntext")]
        public string Dp2 { get; set; }
        [Column("DP3", TypeName = "ntext")]
        public string Dp3 { get; set; }
    }
}
