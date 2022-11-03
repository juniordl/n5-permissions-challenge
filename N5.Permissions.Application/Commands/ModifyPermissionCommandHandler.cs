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
    public class ModifyPermissionCommandHandler : IRequestHandler<ModifyPermissionCommand, int>
    {
        private readonly IGenericRepository<Permission> _repository;
        private readonly IMediator _mediator;

        public ModifyPermissionCommandHandler(IGenericRepository<Permission> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<int> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission
            {
                Id = request.Id,
                EmployeeForename = request.EmployeeForename,
                EmployeeSurname = request.EmployeeSurname,
                PermissionDate = DateTime.Now,
                PermissionTypeId = request.PermissionTypeId
            };
            await Task.Run(() => {
                _repository.Update(permission);
                _repository.Save();
            });

            await _mediator.Publish(new PermissionModified(permission));

            return 1;
        }
    }
}
