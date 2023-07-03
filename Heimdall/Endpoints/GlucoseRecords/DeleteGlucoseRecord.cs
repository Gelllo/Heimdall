using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;

namespace Heimdall.Web.Endpoints.GlucoseRecords
{
    public class DeleteGlucoseRecord : EndpointWithoutRequest
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
            Delete("/glucoserecords/{RecordID}");
            Roles("USER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var req = new DeleteGlucoseRecordRequest() { Id = Route<int>("RecordID") };
                await SendAsync(await _dispatcher.Dispatch<DeleteGlucoseRecordRequest, DeleteGlucoseRecordResponse>(req, ct), StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            
        }
    }
}
