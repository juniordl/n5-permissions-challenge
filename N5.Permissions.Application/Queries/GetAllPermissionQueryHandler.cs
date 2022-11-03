using MediatR;
using N5.Permissions.Domain.Models;
using N5.Permissions.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Application.Queries
{
    public class GetAllPermissionQueryHandler : IRequestHandler<GetAllPermissionQuery, List<Permission>>
    {
        private readonly IGenericRepository<Permission> _repository;

        public GetAllPermissionQueryHandler(IGenericRepository<Permission> repository)
        {
            _repository = repository;
        }

        public Task<List<Permission>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            var listPermissions = _repository.GetAll().ToList();
            return Task.FromResult(listPermissions);
        }
    }
}
