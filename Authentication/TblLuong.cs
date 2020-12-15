using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblLuong")]
    public partial class TblLuong
    {
        [Key]
        public long MaLuong { get; set; }
        public long? MaBac { get; set; }
        public int? MucLuong { get; set; }
        [Column("LuongCB")]
        public int? LuongCb { get; set; }
        [Column("LuongPC")]
        public int? LuongPc { get; set; }
        [StringLength(255)]
        public string NgayNhan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTang { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("DP1", TypeName = "text")]
        public string Dp1 { get; set; }

        [ForeignKey(nameof(MaBac))]
        [InverseProperty(nameof(TblBacLuong.TblLuong))]
        public virtual TblBacLuong MaBacNavigation { get; set; }
    }
}
