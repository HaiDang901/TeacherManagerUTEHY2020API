using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblBacLuong")]
    public partial class TblBacLuong
    {
        public TblBacLuong()
        {
            TblCanBoGiangVien = new HashSet<TblCanBoGiangVien>();
            TblLuong = new HashSet<TblLuong>();
        }

        [Key]
        public long MaBac { get; set; }
        [StringLength(255)]
        public string TenBac { get; set; }
        public double? HeSoBacLg { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "ntext")]
        public string NhomBac { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        [StringLength(50)]
        public string NguoiTao { get; set; }
        [Column("DP1", TypeName = "text")]
        public string Dp1 { get; set; }

        [InverseProperty("MaBacNavigation")]
        public virtual ICollection<TblCanBoGiangVien> TblCanBoGiangVien { get; set; }
        [InverseProperty("MaBacNavigation")]
        public virtual ICollection<TblLuong> TblLuong { get; set; }
    }
}
