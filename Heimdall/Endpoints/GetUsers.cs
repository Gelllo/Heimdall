using FastEndpoints;
using Heimdall.Application;
using Heimdall.Domain.UsersDomain.Request;
using Heimdall.Domain.UsersDomain.Response;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Heimdall.Endpoints
{

    public class GetUsers: Endpoint<GetUsersRequest, GetUsersResponse>
    {
        private IQueryDispatcher _dispatcher;
        private ILogger _logger;

        public GetUsers(IQueryDispatcher dispatcher, ILogger logger)
        {
            this._dispatcher = dispatcher;
            this._logger = logger;
        }
        public override void Configure()
        {
            Get("/users/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetUsersRequest r, CancellationToken c)
        {
            _logger.Error(new Exception("Random"),"Random");
            await SendAsync(await _dispatcher.Dispatch<GetUsersRequest, GetUsersResponse>(r, c));
        }
    }
}
