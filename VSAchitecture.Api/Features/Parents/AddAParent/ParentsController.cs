using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Parents.AddAParent;

[Route("api/parents")]
[ApiController]
public class ParentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Add([FromBody] AddAParentCommand command)
    {
        var parentId = await _mediator.Send(command);
        return AcceptedAtAction("/api/parents", new { Id = parentId}, parentId);
    }
}