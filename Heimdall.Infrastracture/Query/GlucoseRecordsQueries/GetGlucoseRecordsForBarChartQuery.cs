using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;

namespace Heimdall.Infrastracture.Database.Query.GlucoseRecordsQueries
{
    public class GetGlucoseRecordsForBarChartQuery : IQueryHandler<GetGlucoseRecordsForBarChartRequest, GetGlucoseRecordsForChartsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGlucoseRecordsForBarChartQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<GetGlucoseRecordsForChartsResponse> Handle(GetGlucoseRecordsForBarChartRequest query, CancellationToken cancellation)
        {
            return new GetGlucoseRecordsForChartsResponse(){ChartsData = await _unitOfWork.GlucoseRecordRepository.GetGlucoseRecordsForBarChart(query.UserID)};
        }
    }
}