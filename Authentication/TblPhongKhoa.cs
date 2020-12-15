using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblPhongKhoa")]
    public partial class TblPhongKhoa
    {
        public TblPhongKhoa()
        {
            TblBoMonTrungTam = new HashSet<TblBoMonTrungTam>();
            TblCanBoGiangVien = new HashSet<TblCanBoGiangVien>();
            TblHocPhan = new HashSet<TblHocPhan>();
        }

        [Key]
        [Column("MaPK")]
        [StringLength(10)]
        public string MaPk { get; set; }
        [StringLength(150)]
        public string TenPhongKhoa { get; set; }
        public int? SoLuongNhanSu { get; set; }
        public int? PhanLoai { get; set; }
        [Column(TypeName = "ntext")]
        public string DiaChi { get; set; }
        [Column(TypeName = "ntext")]
        public string DienThoai { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "ntext")]
        public string Webiste { get; set; }
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

        [InverseProperty("MaPkNavigation")]
        public virtual ICollection<TblBoMonTrungTam> TblBoMonTrungTam { get; set; }
        [InverseProperty("MaPkNavigation")]
        public virtual ICollection<TblCanBoGiangVien> TblCanBoGiangVien { get; set; }
        [InverseProperty("MaPkNavigation")]
        public virtual ICollection<TblHocPhan> TblHocPhan { get; set; }
    }
}
