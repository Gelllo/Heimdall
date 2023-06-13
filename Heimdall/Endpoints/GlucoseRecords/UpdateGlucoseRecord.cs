using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;
using ILogger = Serilog.ILogger;

namespace Heimdall.Web.Endpoints.GlucoseRecords
{
    public class UpdateGlucoseRecord : Endpoint<UpdateGlucoseRecordRequest, UpdateGlucoseRecordResponse>
    {
        private readonly ICommandDispatcher _dispatcher;
        private readonly ILogger _logger;

        public UpdateGlucoseRecord(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Put("/glucoserecords/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateGlucoseRecordRequest req, CancellationToken ct)
        {
            await SendAsync(
                await _dispatcher.Dispatch<UpdateGlucoseRecordRequest, UpdateGlucoseRecordResponse>(req, ct));
        }
    }
}
