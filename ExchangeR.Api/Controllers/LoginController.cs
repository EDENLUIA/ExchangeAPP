
using ExchangeR.Api.Models;
using ExchangeR.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExchangeR.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILogger _logger;    
        private IConfiguration _config;

        public LoginController(
            ILogger<LoginController> logger,
           
            IConfiguration config)
        {
           
            _logger = logger;          
            _config = config;
        }


        [AllowAnonymous]
        [HttpPost("SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn(LoginRequest request)
        {
            //TODO: Validar que el usuario este registrado en el sistema

            return Ok(new { Token = GenerateJwtToken(request.User) });
        }

        public string GenerateJwtToken(string accountId)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, accountId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Auth:Secret").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var SecurityToken = new JwtSecurityToken(
            
               claims: claims,
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: creds

            );
            var token = new JwtSecurityTokenHandler().WriteToken(SecurityToken);
            return token;
        }
    }
}
