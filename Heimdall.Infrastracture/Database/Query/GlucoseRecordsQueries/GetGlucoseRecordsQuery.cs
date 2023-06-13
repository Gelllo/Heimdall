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
    public class GetGlucoseRecordsQuery: IQueryHandler<GetGlucoseRecordsRequest, GetGlucoseRecordsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGlucoseRecordsQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<GetGlucoseRecordsResponse> Handle(GetGlucoseRecordsRequest query, CancellationToken cancellation)
        {
            return _mapper.Map<GetGlucoseRecordsResponse>(await _unitOfWork.GlucoseRecordRepository.GetGlucoseRecordsAsync());
        }
    }
}
