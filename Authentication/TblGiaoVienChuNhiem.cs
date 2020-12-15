using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblGiaoVienChuNhiem")]
    public partial class TblGiaoVienChuNhiem
    {
        [Key]
        [Column("MaGVCN")]
        public long MaGvcn { get; set; }
        [StringLength(10)]
        public string MaLop { get; set; }
        [Column("MaCBGV")]
        [StringLength(10)]
        public string MaCbgv { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BatDau { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KetThuc { get; set; }
        public int? HieuLuc { get; set; }
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

        [ForeignKey(nameof(MaCbgv))]
        [InverseProperty(nameof(TblCanBoGiangVien.TblGiaoVienChuNhiem))]
        public virtual TblCanBoGiangVien MaCbgvNavigation { get; set; }
    }
}
