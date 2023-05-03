namespace Heimdall.Domain.UsersDomain.Request
{
    public record GetUsersRequest
    {
        public string UserId { get; set; }
    }
}
