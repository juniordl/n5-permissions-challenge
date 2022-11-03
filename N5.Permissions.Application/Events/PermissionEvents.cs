using MediatR;
using N5.Permissions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Application.Events
{
    public class PermissionCreated : INotification { 
        public Permission NewPermission { get; set; }
        public PermissionCreated(Permission newPermission)
        {
            NewPermission = newPermission;
        }
    }
    public class PermissionModified : INotification
    {
        public Permission ModifyPermission { get; set; }
        public PermissionModified(Permission modifyPermission)
        {
            ModifyPermission = modifyPermission;
        }
    }
}
