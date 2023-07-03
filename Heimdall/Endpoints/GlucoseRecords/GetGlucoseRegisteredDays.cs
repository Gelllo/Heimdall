using FastEndpoints;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;
using Heimdall.Application;

namespace Heimdall.Web.Endpoints.GlucoseRecords
{
    public class GetGlucoseRegisteredDays : EndpointWithoutRequest
    {
        private readonly IQueryDispatcher _dispatcher;
        private readonly ILogger _logger;

        public GetGlucoseRegisteredDays(IQueryDispatcher dispatcher, ILogger _logger)
        {
            _dispatcher = dispatcher;
            _logger = _logger;
        }

        public override void Configure()
        {
            Get("/glucoserecords/registereddays/{UserID}");
            Roles("USER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var req = new GetGlucoseRegisteredDaysRequest() { UserID = Route<string>("UserID") };

                await SendAsync(await _dispatcher.Dispatch<GetGlucoseRegisteredDaysRequest, GetGlucoseRegisteredDaysResponse>(req, ct), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            
        }
    }
}
