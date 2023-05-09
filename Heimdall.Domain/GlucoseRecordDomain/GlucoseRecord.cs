using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Domain.GlucoseRecordDomain
{
    [Table("GlucoseRecords")]
    public class GlucoseRecord
    {
        [Key]
        public int Id { get; set; }

        [Column("GlucoseLevel", TypeName = "nvarchar(200)"), Required]
        public string GlucoseLevel { get; set; }

        [Column("DateRegistered", TypeName = "nvarchar(200)"), Required]
        public DateTime DateRegistered { get; set; }

        [Column("Color", TypeName = "nvarchar(200)"), Required]
        public string Color { get; set; }
    }
}
