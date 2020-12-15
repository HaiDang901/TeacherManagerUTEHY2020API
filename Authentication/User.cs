using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    [Table("user")]
    public partial class User
    {
        public User()
        {
            RefreshToken = new HashSet<RefreshToken>();
        }

        [Key]
        [Column("user_id")]
        [StringLength(50)]
        public string UserId { get; set; }
        [Column("hoten")]
        [StringLength(50)]
        public string Hoten { get; set; }
        [Column("ngaysinh", TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }
        [Column("diachi")]
        [StringLength(250)]
        public string Diachi { get; set; }
        [Column("gioitinh")]
        [StringLength(30)]
        public string Gioitinh { get; set; }
        [Column("email")]
        [StringLength(150)]
        public string Email { get; set; }
        [Column("taikhoan")]
        [StringLength(30)]
        public string Taikhoan { get; set; }
        [Column("matkhau")]
        [StringLength(60)]
        public string Matkhau { get; set; }
        [Column("role")]
        [StringLength(30)]
        public string Role { get; set; }
        [Column("image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
    }
}
