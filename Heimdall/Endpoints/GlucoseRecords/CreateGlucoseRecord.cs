using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Requests.GlucoseRecords.Validation;
using Heimdall.Application.Responses.GlucoseRecords;

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
            Validator<CreateGlucoseRecordRequestValidation>();
            Roles("USER");
        }

        public override async Task HandleAsync(CreateGlucoseRecordRequest req, CancellationToken ct)
        {
            try
            {
                await SendAsync(
                    await _dispatcher.Dispatch<CreateGlucoseRecordRequest, CreateGlucoseRecordResponse>(req, ct), StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            
        }
    }
}
