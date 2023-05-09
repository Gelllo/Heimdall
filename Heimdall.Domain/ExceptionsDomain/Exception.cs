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
    public class Exception
    {
        public int Id { get; set; }

        public string? Error { get; set; }

        public string? Application { get; set; }

        public string MessageTemplate { get; set; }

        public DateTime DateThrown { get; set; }
    }
}
