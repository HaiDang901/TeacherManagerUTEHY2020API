using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblKhenThuongKiLuat")]
    public partial class TblKhenThuongKiLuat
    {
        public TblKhenThuongKiLuat()
        {
            TblCanBoGiangVien = new HashSet<TblCanBoGiangVien>();
        }

        [Key]
        [Column("MaKTKL")]
        public long MaKtkl { get; set; }
        [Column("TenKTKL")]
        [StringLength(255)]
        public string TenKtkl { get; set; }
        [Column(TypeName = "ntext")]
        public string LyDo { get; set; }
        [Column("NgayKT", TypeName = "datetime")]
        public DateTime? NgayKt { get; set; }
        [StringLength(255)]
        public string HinhThuc { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("DP1", TypeName = "text")]
        public string Dp1 { get; set; }

        [InverseProperty("MaKtklNavigation")]
        public virtual ICollection<TblCanBoGiangVien> TblCanBoGiangVien { get; set; }
    }
}
