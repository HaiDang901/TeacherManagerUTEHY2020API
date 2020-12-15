using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblDinhMucHocPhi")]
    public partial class TblDinhMucHocPhi
    {
        [Key]
        [Column("MaDMHP")]
        public long MaDmhp { get; set; }
        [StringLength(10)]
        public string MaLop { get; set; }
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? HocPhiThang { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? HocPhiHocKy { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? HocPhiTinChi { get; set; }
        [Column("HocPhiTinChiLT", TypeName = "numeric(18, 0)")]
        public decimal? HocPhiTinChiLt { get; set; }
        [Column("HocPhiTinChiTH", TypeName = "numeric(18, 0)")]
        public decimal? HocPhiTinChiTh { get; set; }
        public int? HocKy { get; set; }
        public int? NamHoc { get; set; }
        public int? TrangThai { get; set; }
        public int? TinhChat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayBatDau { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayKetThuc { get; set; }
        [Column(TypeName = "ntext")]
        public string QuyetDinh { get; set; }
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
        [StringLength(10)]
        public string MaKhoanThu { get; set; }
    }
}
