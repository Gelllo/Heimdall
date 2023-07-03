using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application.Requests;
using Heimdall.Application.Responses.GlucoseRecords;
using Heimdall.Domain;

namespace Heimdall.Application.Mappings
{
    public class GlucoseRecordMappings: Profile
    {
        public GlucoseRecordMappings()
        {

            CreateMap<GlucoseRecord, GlucoseRecordDTO>()
                .ForMember(dest => dest.DateRegistered,
                    opt => opt.MapFrom(src => src.DateRegistered.ToString("MM-dd-yyyy")));

            CreateMap<GlucoseRecordDTO, GlucoseRecord>()
                .ForMember(dest => dest.DateRegistered, opt => opt.MapFrom(src => DateTime.Parse(src.DateRegistered)));

            CreateMap<GlucoseRecord, CreateGlucoseRecordResponse>()
                .ForMember(dest => dest.GlucoseRecord, opt =>
                    opt.MapFrom(src=> new GlucoseRecord()
                    {
                        DateRegistered = src.DateRegistered,
                        GlucoseLevel = src.GlucoseLevel,
                        Id = src.Id,
                        UserId = src.UserId
                    }));

            CreateMap<GlucoseRecord, UpdateGlucoseRecordResponse>()
                .ForMember(dest => dest.GlucoseRecord, opt =>
                    opt.MapFrom(src => new GlucoseRecord()
                    {
                        DateRegistered = src.DateRegistered,
                        GlucoseLevel = src.GlucoseLevel,
                        Id = src.Id,
                        UserId = src.UserId
                    }));

            CreateMap<IEnumerable<GlucoseRecord>?, GetGlucoseRecordsResponse>()
                .ForMember(dest => dest.GlucoseRecords, opt => opt.MapFrom(src => src));

        }
    }
}
