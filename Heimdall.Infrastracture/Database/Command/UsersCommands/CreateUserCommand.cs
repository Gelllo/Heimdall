using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application;
using Heimdall.Application.Requests.Users;
using Heimdall.Application.Responses.Users;
using Heimdall.Domain.UsersDomain;

namespace Heimdall.Infrastracture.Database.Command.UsersCommands
{
    public class CreateUserCommand : ICommandHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommand(IUnitOfWork uniOfWork, IMapper mapper)
        {
            this._unitOfWork = uniOfWork;
            this._mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellation)
        {
            var userId = await _unitOfWork.UserRepository.InsertUser(_mapper.Map<User>(request));
            return _mapper.Map<CreateUserResponse>(await _unitOfWork.UserRepository.GetUserByID(userId));
        }
    }
}
