using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;
using ILogger = Serilog.ILogger;

namespace Heimdall.Web.Endpoints.GlucoseRecords
{
    public class CreateGlucoseRecord:Endpoint<CreateGlucoseRecordRequest, CreateGlucoseRecordResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public CreateGlucoseRecord(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Post("/glucoserecords/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateGlucoseRecordRequest req, CancellationToken ct)
        {
            await SendAsync(
                await _dispatcher.Dispatch<CreateGlucoseRecordRequest, CreateGlucoseRecordResponse>(req, ct));
        }
    }
}
