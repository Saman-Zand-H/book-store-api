using System.Security.Claims;
using BookStore.Api.DTOs;
using BookStore.Api.Models;
using BookStore.Api.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<ActionResult<string?>> Register([FromBody] UserCreateDto user)
        {
            try
            {
                string token = await _authService.Register(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Authenticate([FromBody] UserLoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string token = await _authService.Authenticate(user.Username, user.Password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<User?>> Get()
        {
            string? username = User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            var user = await _authService.GetUserAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}