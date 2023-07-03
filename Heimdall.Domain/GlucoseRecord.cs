using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Domain
{
    [Table("GlucoseRecords")]
    public class GlucoseRecord
    {
        [Key]
        public int Id { get; set; }

        [Column("GlucoseLevel", TypeName = "int"), Required]
        public int GlucoseLevel { get; set; }

        [Column("DateRegistered", TypeName = "DateTime"), Required]
        public DateTime DateRegistered { get; set; }

        [Column("RegisteredAfter", TypeName = "nvarchar(200)")]
        public string RegisteredAfter { get; set; }

        [Column("UserId", TypeName = "nvarchar(200)"), Required]
        public string UserId { get; set; }
    }

    public static class MealTypes
    {
        public static readonly string[] types = { "BREAKFAST", "LUNCH", "DINNER", "SNACK" };

        public static readonly string BREAKFAST = "BREAKFAST";

        public static readonly string LUNCH = "LUNCH";

        public static readonly string DINNER = "DINNER";

        public static readonly string SNACK = "SNACK";

    }
}
