using FastEndpoints;
using Heimdall.Application.Requests.Users;
using Heimdall.Application.Responses.Users;
using Heimdall.Application;
using ILogger = Serilog.ILogger;

namespace Heimdall.Web.Endpoints.Users
{
    public class UpdateUser : Endpoint<UpdateUserRequest, UpdateUserResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public UpdateUser(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Put("/users/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
        {
            await SendAsync(await _dispatcher.Dispatch<UpdateUserRequest, UpdateUserResponse>(req, ct));
        }
    }
}
