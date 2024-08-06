using InventarySystemAPI.Config;
using InventarySystemAPI.Modules.Authentication.Domain.Interfaces;
using InventarySystemAPI.Modules.Authentication.Domain.Records;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;

namespace InventarySystemAPI.Modules.Authentication.Infrastructure
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        // Request for sign in
        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignInUser([FromBody] SignInBody body)
        {
            try
            {
                var user = await _service.Login(body.username, body.password);
                var JWT = JwtBuilder.Create()
                    .WithAlgorithm(JwtConfig.GetAlgorithm())
                    .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                    .AddClaim("token", user)
                    .Encode();
                var response = new
                {
                    Message = "Success",
                    Data = JWT
                };
                return Ok(response);
            }
            catch (Exception error)
            {
                var response = new
                {
                    Message = "Failed",
                    Data = error.Message
                };
                return BadRequest(response);
            }
        }

        // Request for register user
        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> SignUpUser([FromBody] SignUpBody body)
        {
            try
            {
                await _service.Register(body.userId, body.username, body.password, body.email);
                var response = new
                {
                    Message = "Success",
                    Data = new{
                        User = "User Created"
                    }
                };
                return Ok(response);
            }
            catch (Exception error)
            {
                var response = new
                {
                    Message = "Failed",
                    Data = error.Message,
                };
                return BadRequest(response);
            }
        }
    }
}