using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblSinhvien")]
    public partial class TblSinhvien
    {
        [Key]
        [Column("MaSV")]
        [StringLength(10)]
        public string MaSv { get; set; }
        [Required]
        [StringLength(50)]
        public string HoVaTen { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySinh { get; set; }
        public byte? GioiTinh { get; set; }
        [StringLength(50)]
        public string DanToc { get; set; }
        [StringLength(50)]
        public string SoDinhDanh { get; set; }
        [StringLength(50)]
        public string NoiCap { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCap { get; set; }
        [StringLength(50)]
        public string DienThoai { get; set; }
        [Column(TypeName = "ntext")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string MatKhau { get; set; }
        public int? Quyen { get; set; }
        public int? TrangThai { get; set; }
        [Column(TypeName = "ntext")]
        public string Anh { get; set; }
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
