using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application.Requests.Users;
using Heimdall.Application.Responses.Users;
using Heimdall.Domain.UsersDomain;

namespace Heimdall.Application.Mappings
{
    public class UserMappings: Profile
    {
        public UserMappings()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<User, CreateUserResponse>()
                .ForMember(dest => dest.User, opt =>
                    opt.MapFrom(src => new User()
                    {
                        Email = src.Email,
                        FirstName = src.FirstName,
                        UserID = src.UserID,
                        LastName = src.LastName,
                        Password = src.Password,
                        Id = src.Id
                    }));

            CreateMap<UpdateUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<User, UpdateUserResponse>()
                .ForMember(dest => dest.User, opt =>
                    opt.MapFrom(src => new User()
                    {
                        Email = src.Email,
                        FirstName = src.FirstName,
                        UserID = src.UserID,
                        LastName = src.LastName,
                        Password = src.Password,
                        Id = src.Id
                    }));

            CreateMap<DeleteUserRequest, int>();
        }
    }
}
