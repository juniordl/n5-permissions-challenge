using Microsoft.EntityFrameworkCore;
using N5.Permissions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Infrastructure
{
    public class PermissionContext: DbContext
    {
        public PermissionContext(DbContextOptions<PermissionContext> options): base(options)
        {

        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        
        }
    }
}
