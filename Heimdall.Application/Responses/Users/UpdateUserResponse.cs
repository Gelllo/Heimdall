using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Domain.UsersDomain;

namespace Heimdall.Application.Responses.Users
{
    public record UpdateUserResponse
    {
        public User? User { get; set; }
    }
}
