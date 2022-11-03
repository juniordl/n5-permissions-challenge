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
    public class PermisionModifiedHandler : INotificationHandler<PermissionModified>
    {
        private readonly IElasticsearchRepository _elasticsearchRepository;

        public PermisionModifiedHandler(IElasticsearchRepository elasticsearchRepository)
        {
            _elasticsearchRepository = elasticsearchRepository;
        }

        public Task Handle(PermissionModified notification, CancellationToken cancellationToken)
        {
            _elasticsearchRepository.IndexDocumentAsync(notification.ModifyPermission);
            return Task.CompletedTask;
        }
    }
}
