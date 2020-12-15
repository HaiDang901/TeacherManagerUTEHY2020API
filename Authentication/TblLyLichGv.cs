using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblLyLichGV")]
    public partial class TblLyLichGv
    {
        [Key]
        [Column("MaLL")]
        public long MaLl { get; set; }
        [Column("MaCBGV")]
        [StringLength(10)]
        public string MaCbgv { get; set; }
        [Column("TenLL")]
        [StringLength(255)]
        public string TenLl { get; set; }
        [Column("LoaiLL", TypeName = "ntext")]
        public string LoaiLl { get; set; }
        [Column(TypeName = "ntext")]
        public string LinkBaiBao { get; set; }
        [Column(TypeName = "ntext")]
        public string Ghichu { get; set; }
        public int? Status { get; set; }
        [Column("DP1", TypeName = "text")]
        public string Dp1 { get; set; }

        [ForeignKey(nameof(MaCbgv))]
        [InverseProperty(nameof(TblCanBoGiangVien.TblLyLichGv))]
        public virtual TblCanBoGiangVien MaCbgvNavigation { get; set; }
    }
}
