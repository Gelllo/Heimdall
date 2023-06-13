using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.Users;
using Heimdall.Application.Responses.Users;
using ILogger = Serilog.ILogger;

namespace Heimdall.Web.Endpoints.Users
{

    public class GetUsers : Endpoint<GetUsersRequest, GetUsersResponse>
    {
        private readonly IQueryDispatcher _dispatcher;
        private ILogger _logger;

        public GetUsers(IQueryDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }
        public override void Configure()
        {
            Get("/users/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetUsersRequest r, CancellationToken c)
        { 
            await SendAsync(await _dispatcher.Dispatch<GetUsersRequest, GetUsersResponse>(r, c));
        }
    }
}
