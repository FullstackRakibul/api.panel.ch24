using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using v1.DbContexts.AuthModels;
using v1.DTOs.AuthDTO;
using v1.Services.AuthService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace v1.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(AuthService authService, SignInManager<ApplicationUser> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            var (success, token, errors) = await _authService.RegisterAsync(registerDto);
            if (!success)
                return BadRequest(new { errors });

            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var (success, token, errorMessage) = await _authService.LoginAsync(request.Email, request.Password);
            return success ? Ok(new { token }) : Unauthorized(new { message = errorMessage });
            return Ok();

        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("User logged out successfully");
        }
    }
}
