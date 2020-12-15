using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblHocPhan")]
    public partial class TblHocPhan
    {
        public TblHocPhan()
        {
            TblDkgiangDay = new HashSet<TblDkgiangDay>();
        }

        [Key]
        [Column("MaHP")]
        [StringLength(10)]
        public string MaHp { get; set; }
        [Column("MaPK")]
        [StringLength(10)]
        public string MaPk { get; set; }
        [Column("MaBMTT")]
        [StringLength(10)]
        public string MaBmtt { get; set; }
        [Column(TypeName = "ntext")]
        public string TenHocPhan { get; set; }
        public int? HocKy { get; set; }
        public int? TinhChat { get; set; }
        public double? SoTinChi { get; set; }
        [Column("SoTinChiLT")]
        public double? SoTinChiLt { get; set; }
        [Column("SoTinChiTH")]
        public double? SoTinChiTh { get; set; }
        public double? HeSo { get; set; }
        public int? SoThuTu { get; set; }
        public int? TinhTrungBinh { get; set; }
        public int? TotNghiep { get; set; }
        [Column(TypeName = "ntext")]
        public string DiemThanhPhan { get; set; }
        [Column(TypeName = "ntext")]
        public string NganhApDung { get; set; }
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

        [ForeignKey(nameof(MaPk))]
        [InverseProperty(nameof(TblPhongKhoa.TblHocPhan))]
        public virtual TblPhongKhoa MaPkNavigation { get; set; }
        [InverseProperty("MaHpNavigation")]
        public virtual ICollection<TblDkgiangDay> TblDkgiangDay { get; set; }
    }
}
