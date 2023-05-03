using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Application;
using Heimdall.Domain.UsersDomain;
using Heimdall.Domain.UsersDomain.Request;
using Heimdall.Domain.UsersDomain.Response;

namespace Heimdall.Infrastracture.Database.Query.UsersHandlers
{
    public class GetUsersHandler : IQueryHandler<GetUsersRequest, GetUsersResponse>
    {
        public GetUsersHandler() { }

        public async Task<GetUsersResponse> Handle(GetUsersRequest query, CancellationToken cancellation)
        {
            var random = new GetUsersResponse() { UsersList = new List<User>() };
            return random;
        }
    }
}
