using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblChiTietPhieuThu")]
    public partial class TblChiTietPhieuThu
    {
        [Key]
        public long MaChiTietPhieuThu { get; set; }
        public long? MaPhieuThu { get; set; }
        public long? MaKhoanNo { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? SoTien { get; set; }
        public int? HoaDonDienTu { get; set; }
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
