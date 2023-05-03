using Heimdall.Domain.UsersDomain;

namespace Heimdall.Domain.UsersDomain.Response
{
    public record GetUsersResponse
    {
        public List<User>? UsersList { get; set; }
    }
}
