using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application;
using Heimdall.Application.Requests.GlucoseRecords;
using Heimdall.Application.Responses.GlucoseRecords;

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
            var record = await _unitOfWork.GlucoseRecordRepository.GetGlucoseRecordAsync(request.Id);

            if (record == null)
            {
                throw new Exception("Record doesn't exist");
            }

            record.GlucoseLevel = request.GlucoseRecordDTO.GlucoseLevel;
            DateTime.TryParseExact(request.GlucoseRecordDTO.DateRegistered, "MM-dd-yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime result);

            record.DateRegistered = result;
            record.RegisteredAfter = request.GlucoseRecordDTO.RegisteredAfter;

            return new UpdateGlucoseRecordResponse()
                { GlucoseRecord = await _unitOfWork.GlucoseRecordRepository.UpdateGlucoseRecordAsync(record) };
        }
    }
}
