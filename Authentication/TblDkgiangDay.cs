using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblDKGiangDay")]
    public partial class TblDkgiangDay
    {
        [Key]
        [Column("MaDKGD")]
        public long MaDkgd { get; set; }
        [Column("MaCBGV")]
        [StringLength(10)]
        public string MaCbgv { get; set; }
        [Column("MaHP")]
        [StringLength(10)]
        public string MaHp { get; set; }
        [Column("NgayDK", TypeName = "datetime")]
        public DateTime? NgayDk { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("DP1", TypeName = "text")]
        public string Dp1 { get; set; }

        [ForeignKey(nameof(MaCbgv))]
        [InverseProperty(nameof(TblCanBoGiangVien.TblDkgiangDay))]
        public virtual TblCanBoGiangVien MaCbgvNavigation { get; set; }
        [ForeignKey(nameof(MaHp))]
        [InverseProperty(nameof(TblHocPhan.TblDkgiangDay))]
        public virtual TblHocPhan MaHpNavigation { get; set; }
    }
}
