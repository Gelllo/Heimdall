using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Domain.ExceptionsDomain
{
    [Table("Exceptional")]
    public class Exception
    {
        [Key]
        public int Id { get; set; }

        [Column("Error", TypeName = "nvarchar(200)")]
        public string? Error { get; set; }

        [Column("Application", TypeName = "nvarchar(200)")]
        public string? Application { get; set; }

        [Column("MessageTemplate", TypeName = "nvarchar(200)")]
        public string MessageTemplate { get; set; }

        [Column("DateThrown", TypeName = "DateTime")]
        public DateTime DateThrown { get; set; }
    }
}
