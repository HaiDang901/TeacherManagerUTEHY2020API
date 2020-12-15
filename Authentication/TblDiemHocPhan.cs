using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblDiemHocPhan")]
    public partial class TblDiemHocPhan
    {
        [Key]
        public long MaDiem { get; set; }
        [Column("MaSV")]
        [StringLength(10)]
        public string MaSv { get; set; }
        [Column("MaHP")]
        [StringLength(10)]
        public string MaHp { get; set; }
        public double? Diem { get; set; }
        public int? HocKy { get; set; }
        public int? NamHoc { get; set; }
        public int? TinhTrang { get; set; }
        public int? ThuTu { get; set; }
        public int? SoLanHoc { get; set; }
        public double? SoTinChi { get; set; }
        public double? HeSo { get; set; }
        public int? SoThuTu { get; set; }
        public int? TinhTrungBinh { get; set; }
        public int? TotNghiep { get; set; }
        [Column(TypeName = "ntext")]
        public string DiemThanhPhan { get; set; }
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
