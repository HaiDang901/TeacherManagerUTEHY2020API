using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblSinhVienLopHoc")]
    public partial class TblSinhVienLopHoc
    {
        [Key]
        [Column("MaSVLH")]
        public long MaSvlh { get; set; }
        [Column("MaSV")]
        [StringLength(10)]
        public string MaSv { get; set; }
        [StringLength(10)]
        public string MaLop { get; set; }
        public int? HoatDong { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayVaoLop { get; set; }
        [Column(TypeName = "text")]
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
