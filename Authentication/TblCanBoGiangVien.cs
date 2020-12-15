using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblCanBoGiangVien")]
    public partial class TblCanBoGiangVien
    {
        public TblCanBoGiangVien()
        {
            TblDkgiangDay = new HashSet<TblDkgiangDay>();
            TblGiaoVienChuNhiem = new HashSet<TblGiaoVienChuNhiem>();
            TblLyLichGv = new HashSet<TblLyLichGv>();
        }

        [Key]
        [Column("MaCBGV")]
        [StringLength(10)]
        public string MaCbgv { get; set; }
        [Column("MaPK")]
        [StringLength(10)]
        public string MaPk { get; set; }
        [Column("MaBMTT")]
        [StringLength(10)]
        public string MaBmtt { get; set; }
        public long? MaNgach { get; set; }
        public long? MaBac { get; set; }
        [Column("MaTDHV")]
        public long? MaTdhv { get; set; }
        [Column("MaKTKL")]
        public long? MaKtkl { get; set; }
        [StringLength(50)]
        public string HoVaTen { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        [Column(TypeName = "ntext")]
        public string MatKhau { get; set; }
        [Column(TypeName = "ntext")]
        public string DienThoai { get; set; }
        [Column(TypeName = "ntext")]
        public string Email { get; set; }
        [StringLength(10)]
        public string ChucDanh { get; set; }
        [Column(TypeName = "text")]
        public string SoTaiKhoan { get; set; }
        public int? Status { get; set; }
        public int? Quyen { get; set; }
        [StringLength(255)]
        public string QueQuan { get; set; }
        [StringLength(50)]
        public string DanToc { get; set; }
        [StringLength(50)]
        public string TonGiao { get; set; }
        [StringLength(255)]
        public string TrinhDo { get; set; }
        [Column(TypeName = "ntext")]
        public string KinhNghiem { get; set; }
        [Column("CMND")]
        [StringLength(20)]
        public string Cmnd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCap { get; set; }
        [StringLength(255)]
        public string AiCap { get; set; }
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

        [ForeignKey(nameof(MaBac))]
        [InverseProperty(nameof(TblBacLuong.TblCanBoGiangVien))]
        public virtual TblBacLuong MaBacNavigation { get; set; }
        [ForeignKey(nameof(MaBmtt))]
        [InverseProperty(nameof(TblBoMonTrungTam.TblCanBoGiangVien))]
        public virtual TblBoMonTrungTam MaBmttNavigation { get; set; }
        [ForeignKey(nameof(MaKtkl))]
        [InverseProperty(nameof(TblKhenThuongKiLuat.TblCanBoGiangVien))]
        public virtual TblKhenThuongKiLuat MaKtklNavigation { get; set; }
        [ForeignKey(nameof(MaNgach))]
        [InverseProperty(nameof(TblNgachCongChuc.TblCanBoGiangVien))]
        public virtual TblNgachCongChuc MaNgachNavigation { get; set; }
        [ForeignKey(nameof(MaPk))]
        [InverseProperty(nameof(TblPhongKhoa.TblCanBoGiangVien))]
        public virtual TblPhongKhoa MaPkNavigation { get; set; }
        [ForeignKey(nameof(MaTdhv))]
        [InverseProperty(nameof(TblTrinhDoHocVan.TblCanBoGiangVien))]
        public virtual TblTrinhDoHocVan MaTdhvNavigation { get; set; }
        [InverseProperty("MaCbgvNavigation")]
        public virtual ICollection<TblDkgiangDay> TblDkgiangDay { get; set; }
        [InverseProperty("MaCbgvNavigation")]
        public virtual ICollection<TblGiaoVienChuNhiem> TblGiaoVienChuNhiem { get; set; }
        [InverseProperty("MaCbgvNavigation")]
        public virtual ICollection<TblLyLichGv> TblLyLichGv { get; set; }
    }
}
