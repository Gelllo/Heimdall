using AutoMapper;
using Heimdall.Application.Requests.Users;
using Heimdall.Application.Responses.Users;
using Heimdall.Application;
using Heimdall.Domain.UsersDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Infrastracture.Database.Command.UsersCommands
{
    public class DeleteUserCommand : ICommandHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUserCommand(IUnitOfWork uniOfWork, IMapper mapper)
        {
            this._unitOfWork = uniOfWork;
            this._mapper = mapper;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellation)
        {
            _unitOfWork.UserRepository.DeleteUser(_mapper.Map<int>(request));
            return new DeleteUserResponse();
        }
    }
}
