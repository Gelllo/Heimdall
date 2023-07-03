using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application;
using Heimdall.Application.Requests;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;
using Heimdall.Domain;

namespace Heimdall.Infrastracture.Database.Query.GlucoseRecordsQueries
{
    public class GetGlucoseRecordsFromSpecifiedDateUntilNowQuery : IQueryHandler<GetGlucoseRecordsFromSpecifiedDateUntilNowRequest, GetGlucoseRecordsFromSpecifiedDateUntilNowResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGlucoseRecordsFromSpecifiedDateUntilNowQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<GetGlucoseRecordsFromSpecifiedDateUntilNowResponse> Handle(GetGlucoseRecordsFromSpecifiedDateUntilNowRequest query, CancellationToken cancellation)
        {
            return new GetGlucoseRecordsFromSpecifiedDateUntilNowResponse()
            {
                GlucoseRecords = _mapper.Map<IEnumerable<GlucoseRecordDTO>>(
                    await _unitOfWork.GlucoseRecordRepository.GetGlucoseRecordsFromSpecifiedDateUntilNow(query.UserID,
                        query.Date))
            };
        }
    }
}