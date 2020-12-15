using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblKhoanThu")]
    public partial class TblKhoanThu
    {
        [Key]
        [StringLength(10)]
        public string MaKhoanThu { get; set; }
        [StringLength(1000)]
        public string MoTa { get; set; }
        public int? TinhChat { get; set; }
        public int? HoaDonDienTu { get; set; }
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
