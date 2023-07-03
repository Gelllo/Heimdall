using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;

namespace Heimdall.Web.Endpoints.GlucoseRecords
{
    public class GetGlucoseRecordsForBarChart : EndpointWithoutRequest
    {
        private readonly IQueryDispatcher _dispatcher;
        private readonly ILogger _logger;

        public GetGlucoseRecordsForBarChart(IQueryDispatcher dispatcher, ILogger _logger)
        {
            _dispatcher = dispatcher;
            _logger = _logger;
        }

        public override void Configure()
        {
            Get("/glucoserecords/charts/{UserID}");
            Roles("USER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var req = new GetGlucoseRecordsForBarChartRequest() { UserID = Route<string>("UserID") };

                await SendAsync(await _dispatcher.Dispatch<GetGlucoseRecordsForBarChartRequest, GetGlucoseRecordsForChartsResponse>(req, ct), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}