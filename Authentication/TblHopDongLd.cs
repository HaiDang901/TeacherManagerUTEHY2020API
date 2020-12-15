using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblHopDongLD")]
    public partial class TblHopDongLd
    {
        [Key]
        [Column("MaHD")]
        public long MaHd { get; set; }
        [Column("MaCBGV")]
        [StringLength(10)]
        public string MaCbgv { get; set; }
        [Column("LoaiHD")]
        [StringLength(255)]
        public string LoaiHd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TuNgay { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DenNgay { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("DP1", TypeName = "text")]
        public string Dp1 { get; set; }
    }
}
