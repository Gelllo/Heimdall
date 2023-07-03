﻿using FastEndpoints;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;

namespace Heimdall.Web.Endpoints.GlucoseRecords
{
    public class GetGlucoseRecordsFromSpecifiedDateUntilNow : EndpointWithoutRequest
    {
        private readonly IQueryDispatcher _dispatcher;
        private readonly ILogger _logger;

        public GetGlucoseRecordsFromSpecifiedDateUntilNow(IQueryDispatcher dispatcher, ILogger _logger)
        {
            _dispatcher = dispatcher;
            _logger = _logger;
        }

        public override void Configure()
        {
            Get("/glucoserecords/fromDateUntilNow/{UserID}/{Date}");
            Roles("USER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var req = new GetGlucoseRecordsFromSpecifiedDateUntilNowRequest() { UserID = Route<string>("UserID"), Date = Route<string>("Date") };
                await SendAsync(await _dispatcher
                    .Dispatch<GetGlucoseRecordsFromSpecifiedDateUntilNowRequest,
                        GetGlucoseRecordsFromSpecifiedDateUntilNowResponse>(req, ct), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

        }
    }
}