using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblLophoc")]
    public partial class TblLophoc
    {
        [Key]
        [StringLength(10)]
        public string MaLop { get; set; }
        [StringLength(10)]
        public string TenLop { get; set; }
        [Required]
        [StringLength(10)]
        public string MaNganhHoc { get; set; }
        [StringLength(10)]
        public string MaKhoaQuanLy { get; set; }
        [StringLength(10)]
        public string NienKhoa { get; set; }
        public int? TrinhDo { get; set; }
        public int? He { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayNhapHoc { get; set; }
        public int? SiSo { get; set; }
        public int? TrangThai { get; set; }
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
