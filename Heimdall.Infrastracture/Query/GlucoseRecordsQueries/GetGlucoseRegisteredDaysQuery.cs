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
    public class GetGlucoseRegisteredDaysQuery : IQueryHandler<GetGlucoseRegisteredDaysRequest, GetGlucoseRegisteredDaysResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGlucoseRegisteredDaysQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<GetGlucoseRegisteredDaysResponse> Handle(GetGlucoseRegisteredDaysRequest query, CancellationToken cancellation)
        {

            return new GetGlucoseRegisteredDaysResponse(){RegisteredDays = await _unitOfWork.GlucoseRecordRepository.GetRegisteredDaysAsync()};
        }
    }
}