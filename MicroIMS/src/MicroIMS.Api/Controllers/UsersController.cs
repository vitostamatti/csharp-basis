using MediatR;
using Microsoft.AspNetCore.Mvc;
using MicroIMS.Contracts.Users;
using MicroIMS.Application.Users.Commands.CreateUser;
using MicroIMS.Application.Users.Queries.GetUserById;
using MapsterMapper;

namespace MicroIMS.Api.Controllers;

[Route("api/users")]
public sealed class UsersController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public UsersController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);
        var result = await _mediator.Send(query, cancellationToken);
        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }
        var response = _mapper.Map<UserResponse>(result.Value);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = _mapper.Map<CreateUserCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return CreatedAtAction(
            nameof(GetUserById),
            new { id = result.Value },
            result.Value
        );
    }
}