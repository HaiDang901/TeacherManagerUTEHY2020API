using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("tblTrinhDoHocVan")]
    public partial class TblTrinhDoHocVan
    {
        public TblTrinhDoHocVan()
        {
            TblCanBoGiangVien = new HashSet<TblCanBoGiangVien>();
        }

        [Key]
        [Column("MaTDHV")]
        public long MaTdhv { get; set; }
        [StringLength(255)]
        public string TenHocVan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NamTotNghiêp { get; set; }
        [StringLength(255)]
        public string ChungChi { get; set; }
        [StringLength(255)]
        public string ChuyenNganhDaoTao { get; set; }
        [Column("DonViCT")]
        [StringLength(255)]
        public string DonViCt { get; set; }
        [Column("TDTinHoc")]
        [StringLength(255)]
        public string TdtinHoc { get; set; }
        [Column("TDNgoaiNgu")]
        [StringLength(255)]
        public string TdngoaiNgu { get; set; }
        [StringLength(10)]
        public string SoNamDay { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("DP1", TypeName = "text")]
        public string Dp1 { get; set; }

        [InverseProperty("MaTdhvNavigation")]
        public virtual ICollection<TblCanBoGiangVien> TblCanBoGiangVien { get; set; }
    }
}
