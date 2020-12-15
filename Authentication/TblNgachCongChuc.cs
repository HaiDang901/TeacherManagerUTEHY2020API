using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblNgachCongChuc")]
    public partial class TblNgachCongChuc
    {
        public TblNgachCongChuc()
        {
            TblCanBoGiangVien = new HashSet<TblCanBoGiangVien>();
        }

        [Key]
        public long MaNgach { get; set; }
        [StringLength(100)]
        public string MaSo { get; set; }
        [StringLength(255)]
        public string TenNgach { get; set; }
        [StringLength(255)]
        public string MoTa { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        [StringLength(50)]
        public string NguoiTao { get; set; }
        [Column("DP1", TypeName = "text")]
        public string Dp1 { get; set; }
        [Column("DP2", TypeName = "text")]
        public string Dp2 { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [InverseProperty("MaNgachNavigation")]
        public virtual ICollection<TblCanBoGiangVien> TblCanBoGiangVien { get; set; }
    }
}
