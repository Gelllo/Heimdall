using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Application;
using Heimdall.Application.Repository;
using Heimdall.Domain.UsersDomain;
using Heimdall.Domain.UsersDomain.Request;
using Heimdall.Domain.UsersDomain.Response;

namespace Heimdall.Infrastracture.Database.Query.UsersHandlers
{
    public class GetUsersHandler : IQueryHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest query, CancellationToken cancellation)
        {
            var users = new GetUsersResponse() { UsersList = await _unitOfWork.UserRepository.GetUsersAsync()};
            return users;
        }
    }
}
