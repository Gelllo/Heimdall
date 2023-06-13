using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;
using ILogger = Serilog.ILogger;

namespace Heimdall.Web.Endpoints.GlucoseRecords
{
    public class DeleteGlucoseRecord : Endpoint<DeleteGlucoseRecordRequest, DeleteGlucoseRecordResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public DeleteGlucoseRecord(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Delete("/glucoserecords/");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteGlucoseRecordRequest req, CancellationToken ct)
        {
            await SendAsync(await _dispatcher.Dispatch<DeleteGlucoseRecordRequest, DeleteGlucoseRecordResponse>(req, ct));
        }
    }
}
