using FastEndpoints;
using Heimdall.Application.Requests.Users;
using Heimdall.Application.Responses.Users;
using Heimdall.Application;
using ILogger = Serilog.ILogger;

namespace Heimdall.Web.Endpoints.Users
{
    public class DeleteUser : Endpoint<DeleteUserRequest, DeleteUserResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public DeleteUser(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Delete("/users/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
        {
            await SendAsync(await _dispatcher.Dispatch<DeleteUserRequest, DeleteUserResponse>(req, ct));
        }
    }
}
