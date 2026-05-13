using APIsprint.DTOs.AuthDTOs;
using APIsprint.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIsprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                var token = await _authService.LoginAsync(dto);

                return Ok(new
                {
                    token = token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    message = ex.Message
                });
            }
        }
    }
}