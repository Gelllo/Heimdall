using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;
using ILogger = Serilog.ILogger;

namespace Heimdall.Web.Endpoints.GlucoseRecords
{
    public class GetGlucoseRecords : Endpoint<GetGlucoseRecordsRequest, GetGlucoseRecordsResponse>
    {
        private readonly IQueryDispatcher _dispatcher;
        private readonly ILogger _logger;

        public GetGlucoseRecords(IQueryDispatcher dispatcher, ILogger _logger)
        {
            _dispatcher = dispatcher;
            _logger = _logger;
        }

        public override void Configure()
        {
            Get("/glucorerecords/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetGlucoseRecordsRequest req, CancellationToken ct)
        {
            await SendAsync(await _dispatcher.Dispatch<GetGlucoseRecordsRequest, GetGlucoseRecordsResponse>(req, ct));
        }
    }
}
