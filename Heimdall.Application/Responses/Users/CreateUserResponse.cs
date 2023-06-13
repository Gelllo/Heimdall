using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Domain.UsersDomain;

namespace Heimdall.Application.Responses.Users
{
    public record CreateUserResponse
    {
        public User? User { get; set; }
    }
}
