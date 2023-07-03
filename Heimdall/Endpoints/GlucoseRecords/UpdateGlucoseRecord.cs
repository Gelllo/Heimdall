using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Requests.GlucoseRecords.Validation;
using Heimdall.Application.Responses.GlucoseRecords;

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
            Put("/glucoserecords/{RecordID}");
            Validator<UpdateGlucoseRecordRequestValidation>();
            Roles("USER");
        }

        public override async Task HandleAsync(UpdateGlucoseRecordRequest req, CancellationToken ct)
        {
            try
            {
                req.Id = Route<int>("RecordID");
                await SendAsync(
                    await _dispatcher.Dispatch<UpdateGlucoseRecordRequest, UpdateGlucoseRecordResponse>(req, ct));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}
