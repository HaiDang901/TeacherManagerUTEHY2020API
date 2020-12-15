using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblBoMonTrungTam")]
    public partial class TblBoMonTrungTam
    {
        public TblBoMonTrungTam()
        {
            TblCanBoGiangVien = new HashSet<TblCanBoGiangVien>();
        }

        [Key]
        [Column("MaBMTT")]
        [StringLength(10)]
        public string MaBmtt { get; set; }
        [Column("TenBMTT")]
        [StringLength(50)]
        public string TenBmtt { get; set; }
        [Column("MaPK")]
        [StringLength(10)]
        public string MaPk { get; set; }
        public int? SoLuongNhanSu { get; set; }
        public int? PhanLoai { get; set; }
        [Column(TypeName = "ntext")]
        public string DiaChi { get; set; }
        [StringLength(12)]
        public string DienThoai { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Website { get; set; }
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
        [InverseProperty(nameof(TblPhongKhoa.TblBoMonTrungTam))]
        public virtual TblPhongKhoa MaPkNavigation { get; set; }
        [InverseProperty("MaBmttNavigation")]
        public virtual ICollection<TblCanBoGiangVien> TblCanBoGiangVien { get; set; }
    }
}
