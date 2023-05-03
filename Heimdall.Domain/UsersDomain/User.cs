using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Domain.UsersDomain
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column("Username",TypeName = "nvarchar(200)"), Required]
        public string Username { get; set; }

        [Column("Email", TypeName = "nvarchar(200)"), Required]
        public string Email { get; set; }

        [Column("Password", TypeName = "nvarchar(200)"), Required]
        public string Password { get; set; }

    }
}
