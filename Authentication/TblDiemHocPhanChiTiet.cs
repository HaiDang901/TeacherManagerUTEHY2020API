using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblDiemHocPhanChiTiet")]
    public partial class TblDiemHocPhanChiTiet
    {
        [Key]
        public int ThuTu { get; set; }
        [Key]
        [Column("MaSV")]
        [StringLength(10)]
        public string MaSv { get; set; }
        [Key]
        [Column("MaHP")]
        [StringLength(10)]
        public string MaHp { get; set; }
        public double? Diem { get; set; }
        public int? HocKy { get; set; }
        public int? NamHoc { get; set; }
        public int? TinhTrang { get; set; }
        public int? KhaoSat { get; set; }
        [Column(TypeName = "text")]
        public string DiemThanhPhan { get; set; }
        [StringLength(10)]
        public string NguoiDay { get; set; }
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
