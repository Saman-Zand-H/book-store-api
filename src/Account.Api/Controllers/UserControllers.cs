using System.Security.Claims;
using Account.App.Commands;
using Account.App.Queries;
using Account.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ISender mediator) : ControllerBase
    {
        // add mediatr 
        private readonly ISender _mediator = mediator;

        [HttpPost("register")]
        public async Task<ActionResult<string?>> Register([FromBody] CreateUserCommand user)
        {
            var result = await _mediator.Send(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Authenticate([FromBody] LoginCommand user)
        {
            var result = await _mediator.Send(user);
            return Ok(result.Token);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<User>> Get()
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);
            var result = await _mediator.Send(new GetUserByTokenQuery { Token = token });
            return Ok(result);
        }
    }
}