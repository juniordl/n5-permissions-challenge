using MediatR;
using N5.Permissions.Application.Events;
using N5.Permissions.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Application.Commands.EventHandler
{
    public class PermissionCreatedHandler : INotificationHandler<PermissionCreated>
    {
        private readonly IElasticsearchRepository _elasticsearchRepository;

        public PermissionCreatedHandler(IElasticsearchRepository elasticsearchRepository)
        {
            _elasticsearchRepository = elasticsearchRepository;
        }

        public Task Handle(PermissionCreated notification, CancellationToken cancellationToken)
        {
            _elasticsearchRepository.IndexDocumentAsync(notification.NewPermission);
            return Task.CompletedTask;
        }
    }
}
