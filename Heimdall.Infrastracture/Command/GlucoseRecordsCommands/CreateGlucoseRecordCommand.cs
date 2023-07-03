using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;
using Heimdall.Domain;

namespace Heimdall.Infrastracture.Database.Command.GlucoseRecordsCommands
{
    public class CreateGlucoseRecordCommand: ICommandHandler<CreateGlucoseRecordRequest, CreateGlucoseRecordResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGlucoseRecordCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<CreateGlucoseRecordResponse> Handle(CreateGlucoseRecordRequest request, CancellationToken cancellation)
        {
            var glucoseRecordId =
                await _unitOfWork.GlucoseRecordRepository.InsertGlucoseRecord(_mapper.Map<GlucoseRecord>(request.GlucoseRecordDTO));
            return new CreateGlucoseRecordResponse()
                { GlucoseRecord = await _unitOfWork.GlucoseRecordRepository.GetGlucoseRecordByID(glucoseRecordId) };
        }
    }
}
