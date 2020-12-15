using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblChuongTrinhDaoTaoChiTiet")]
    public partial class TblChuongTrinhDaoTaoChiTiet
    {
        [Key]
        [Column("MaCTDT")]
        [StringLength(10)]
        public string MaCtdt { get; set; }
        [Column("MaHP")]
        [StringLength(10)]
        public string MaHp { get; set; }
        public int? TinhTrang { get; set; }
        public int? HocKy { get; set; }
        public int? NamHoc { get; set; }
        [Column("SoTT")]
        public int? SoTt { get; set; }
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
