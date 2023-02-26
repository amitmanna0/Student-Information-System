using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentInformation.Data;
using StudentInformation.DTOs;
using StudentInformation.Infrastructure;
using StudentInformation.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StudentInformation.Controllers
{
    /// <summary>
    /// This is Authentication section
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly StudentInformationContext _context;
        public readonly IConfiguration _configuration;
        public AuthController(StudentInformationContext context, IConfiguration configuration )
        {
            _context = context;
            _configuration = configuration;
    }
        [HttpPost("register")]
        public async Task<ActionResult<serviceResponse<string>>> Register(RegistrationDto request)
        {
            var serviceObj = new serviceResponse<string>();

            var user = new User {
                Name=request.Name,
                Email=request.Email,
                StudentRoll = request.StudentRoll,
                Password = request.Password,
            };
            _context.TBUser.Add(user);
            await _context.SaveChangesAsync();
            serviceObj.message = "User Registered Successfully";

            return Ok(serviceObj);
        }
      
        [HttpPost("login")]
        public async Task<ActionResult<serviceResponse<string>>> Login(LoginDto request)
        {
            var serviceObj = new serviceResponse<string>();

            var requestData = await _context.TBUser.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(request.Email));
            if (requestData == null)
            {
                serviceObj.message = "User not found";
                return BadRequest(serviceObj);
            }
            if(requestData.Password != request.Password)
            {
                serviceObj.message = "Something went wrong";
                return BadRequest(serviceObj);
            }
            else
            {
                
                string token = CreateToken(requestData);
                serviceObj.data = token;
                serviceObj.message = "logged in";
                return Ok(serviceObj);
            }
        }
        private string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        
    }
}
