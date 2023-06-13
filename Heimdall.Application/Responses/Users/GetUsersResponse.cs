using Heimdall.Domain.UsersDomain;

namespace Heimdall.Application.Responses.Users
{
    public record GetUsersResponse
    {
        public IEnumerable<User>? UsersList { get; set; }
    }
}
