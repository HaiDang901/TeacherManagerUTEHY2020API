using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblSoGhiNoSinhVien")]
    public partial class TblSoGhiNoSinhVien
    {
        [Key]
        public long MaKhoanNo { get; set; }
        [Required]
        [Column("MaSV")]
        [StringLength(10)]
        public string MaSv { get; set; }
        [Required]
        [StringLength(10)]
        public string MaKhoanThu { get; set; }
        [Column("MaHP")]
        [StringLength(10)]
        public string MaHp { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? SoTienCanThu { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? SoTienDaThu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BatDau { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KetThuc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayThu { get; set; }
        public int? NamTaiKhoa { get; set; }
        public int? TinhTrang { get; set; }
        public int? ChonSan { get; set; }
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
