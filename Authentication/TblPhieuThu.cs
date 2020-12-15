using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblPhieuThu")]
    public partial class TblPhieuThu
    {
        [Key]
        public long MaPhieuThu { get; set; }
        public int? SoHieu { get; set; }
        public int? NamTaiKhoa { get; set; }
        [StringLength(20)]
        public string MaGiaoDich { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Ngay { get; set; }
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }
        [StringLength(50)]
        public string NguoiThu { get; set; }
        [Required]
        [StringLength(10)]
        public string MaNguoiThu { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? TongTien { get; set; }
        public int? HoaDonDienTu { get; set; }
        [Column(TypeName = "text")]
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
