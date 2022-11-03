using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5.Permissions.API.Wrappers;
using N5.Permissions.Application.Commands;
using N5.Permissions.Application.Queries;
using N5.Permissions.Domain.Models;
using N5.Permissions.Infrastructure;
using Serilog;

namespace N5.Permissions.API.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("RequestPermission")]
        public async Task<IActionResult> PostRequestPermissionAsync(RequestPermissionCommand command)
        {
            var response = await _mediator.Send(command);
            Log.Information("Operation: RequestPermission - payload: {0}", command);
            return Ok(new Response<RequestPermissionCommand>(command, "Create Permission Success"));
        }

        [HttpPost]
        [Route("ModifyPermission")]
        public async Task<IActionResult> PostModifyPermissionAsync(ModifyPermissionCommand command)
        {
            var response = await _mediator.Send(command);
            Log.Information("Operation: ModifyPermission - payload: {0}", command);
            return Ok(new Response<ModifyPermissionCommand>(command, "Update Permission Success"));
        }

        [HttpGet]
        [Route("GetAllPermission")]
        public async Task<IActionResult> GetAllPermissionAsync()
        {
            var response = await _mediator.Send(new GetAllPermissionQuery());
            Log.Information("Operation: GetAllPermission");
            return Ok(new Response<List<Permission>>(response));
        }
    }
}
