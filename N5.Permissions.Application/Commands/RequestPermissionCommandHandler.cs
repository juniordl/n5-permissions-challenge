using MediatR;
using N5.Permissions.Application.Events;
using N5.Permissions.Domain.Models;
using N5.Permissions.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Application.Commands
{
    public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand, int>
    {
        private readonly IGenericRepository<Permission> _repository;
        private readonly IMediator _mediator;

        public RequestPermissionCommandHandler(IGenericRepository<Permission> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<int> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission { 
                EmployeeForename = request.EmployeeForename, 
                EmployeeSurname = request.EmployeeSurname, 
                PermissionDate = DateTime.Now, 
                PermissionTypeId = request.PermissionTypeId 
            };
            await Task.Run(() => {
                _repository.Insert(permission);
                _repository.Save();
            });


            await _mediator.Publish(new PermissionCreated(permission));

            return 1;
        }
    }
}
