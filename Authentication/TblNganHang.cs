using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblNganHang")]
    public partial class TblNganHang
    {
        [Key]
        [StringLength(10)]
        public string MaNganHang { get; set; }
        [StringLength(1000)]
        public string Ten { get; set; }
        [StringLength(300)]
        public string DiaChi { get; set; }
        [Column(TypeName = "text")]
        public string MatKhau { get; set; }
        public int? KichHoat { get; set; }
        [Column(TypeName = "text")]
        public string GhiChu { get; set; }
        [StringLength(50)]
        public string NgayTao { get; set; }
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
