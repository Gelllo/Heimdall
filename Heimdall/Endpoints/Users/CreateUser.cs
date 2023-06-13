using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.Users;
using Heimdall.Application.Responses.Users;
using ILogger = Serilog.ILogger;

namespace Heimdall.Web.Endpoints.Users
{
    public class CreateUser:Endpoint<CreateUserRequest, CreateUserResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public CreateUser(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Post("/users/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
        {
            await SendAsync(await _dispatcher.Dispatch<CreateUserRequest, CreateUserResponse>(req, ct));
        }
    }
}
