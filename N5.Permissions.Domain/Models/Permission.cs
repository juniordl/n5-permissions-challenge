using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace N5.Permissions.Domain.Models
{
    public class Permission: BaseEntity
    {
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionTypeId { get; set; }
        [ForeignKey("PermissionTypeId")]
        public virtual PermissionType PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
