using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOAN52.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(255)")]
        public string FullName { get; set; }

        //[Column("image_url")][StringLength(300)]
        //public string ImageUrl { get; set; }
    }
}
