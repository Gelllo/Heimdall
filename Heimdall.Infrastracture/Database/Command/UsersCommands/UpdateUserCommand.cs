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
    public class UpdateUserCommand : ICommandHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IUnitOfWork uniOfWork, IMapper mapper)
        {
            this._unitOfWork = uniOfWork;
            this._mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellation)
        {
            return _mapper.Map<UpdateUserResponse>(await _unitOfWork.UserRepository.UpdateUserAsync(_mapper.Map<User>(request)));
        }
    }
}
