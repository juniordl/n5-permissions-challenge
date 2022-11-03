using N5.Permissions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Infrastructure.Repositories
{
    public interface IElasticsearchRepository
    {
        Task IndexDocumentAsync(Permission permission);
    }
}
