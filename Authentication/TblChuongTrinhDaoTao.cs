using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblChuongTrinhDaoTao")]
    public partial class TblChuongTrinhDaoTao
    {
        [Key]
        [Column("MaCTDT")]
        [StringLength(10)]
        public string MaCtdt { get; set; }
        [StringLength(10)]
        public string MaNganh { get; set; }
        [Column("MaPK")]
        [StringLength(10)]
        public string MaPk { get; set; }
        [Column("MaBMTT")]
        [StringLength(10)]
        public string MaBmtt { get; set; }
        [Column("TenCTDT", TypeName = "ntext")]
        public string TenCtdt { get; set; }
        public double? SoTinChi { get; set; }
        [Column("NamTS")]
        public int? NamTs { get; set; }
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
    }
}
