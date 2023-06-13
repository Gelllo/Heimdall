using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Heimdall.Application;
using Heimdall.Application.Repository;
using Heimdall.Application.Requests.Users;
using Heimdall.Application.Responses.Users;


namespace Heimdall.Infrastracture.Database.Query.UsersHandlers
{
    public class GetUsersQuery : IQueryHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsersQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest query, CancellationToken cancellation)
        {
            return _mapper.Map<GetUsersResponse>(await _unitOfWork.UserRepository.GetUsersAsync());
        }
    }
}
