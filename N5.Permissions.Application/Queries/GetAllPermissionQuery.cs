using MediatR;
using N5.Permissions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.Application.Queries
{
    public class GetAllPermissionQuery: IRequest<List<Permission>>
    {
    }
}
