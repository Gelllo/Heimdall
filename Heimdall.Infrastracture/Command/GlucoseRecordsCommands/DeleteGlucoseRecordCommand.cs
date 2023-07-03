using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;

namespace Heimdall.Infrastracture.Database.Command.GlucoseRecordsCommands
{
    public class DeleteGlucoseRecordCommand : ICommandHandler<DeleteGlucoseRecordRequest, DeleteGlucoseRecordResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGlucoseRecordCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteGlucoseRecordResponse> Handle(DeleteGlucoseRecordRequest request, CancellationToken cancellation)
        {
            _unitOfWork.GlucoseRecordRepository.DeleteGlucoseRecord(request.Id);
            return new DeleteGlucoseRecordResponse();
        }
    }
}
