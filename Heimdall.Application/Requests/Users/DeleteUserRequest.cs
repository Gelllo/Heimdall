using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Application.Requests.Users
{
    public record DeleteUserRequest
    {
        public int Id { get; set; }
    }
}
