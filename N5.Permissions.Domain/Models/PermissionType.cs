using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace N5.Permissions.Domain.Models
{
    public class PermissionType: BaseEntity
    {
        public string Description { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
