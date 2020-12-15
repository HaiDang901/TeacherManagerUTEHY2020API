using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN52.Authentication
{
    public partial class RefreshToken
    {
        [Key]
        [Column("token_id")]
        public int TokenId { get; set; }
        [Required]
        [Column("user_id")]
        [StringLength(50)]
        public string UserId { get; set; }
        [Column("token")]
        [StringLength(200)]
        public string Token { get; set; }
        [Column("expiry_date", TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("RefreshToken")]
        public virtual User User { get; set; }
    }
}
