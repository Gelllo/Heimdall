using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;
using Heimdall.Domain.GlucoseRecordDomain;

namespace Heimdall.Infrastracture.Database.Command.GlucoseRecordsCommands
{
    public class UpdateGlucoseRecordCommand: ICommandHandler<UpdateGlucoseRecordRequest, UpdateGlucoseRecordResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGlucoseRecordCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<UpdateGlucoseRecordResponse> Handle(UpdateGlucoseRecordRequest request, CancellationToken cancellation)
        {
            return _mapper.Map<UpdateGlucoseRecordResponse>(
                await _unitOfWork.GlucoseRecordRepository.UpsertGlucoseRecordAsync(
                    _mapper.Map<GlucoseRecord>(request)));
        }
    }
}
