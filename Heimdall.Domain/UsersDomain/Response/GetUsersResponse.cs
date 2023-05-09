using Heimdall.Domain.UsersDomain;

namespace Heimdall.Domain.UsersDomain.Response
{
    public record GetUsersResponse
    {
        public IEnumerable<User>? UsersList { get; set; }
    }
}
