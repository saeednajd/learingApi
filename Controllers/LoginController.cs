using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using thirdapi.Model;
using webapitwo;
using webapitwo.Model;

namespace thirdapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Libcontext _context;
        private readonly IConfiguration _config;

        public LoginController(Libcontext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }



        [AllowAnonymous]
        [HttpPost]
        [Route("/api/[controller]/login")]

        public IActionResult Login([FromBody] Userlogin userlogin)
        {

            var user = Authenticate(userlogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            User Authenticate(Userlogin userlogin)
            {
                var myuser = _context.Users.FirstOrDefault(x => x.Username.ToLower() == userlogin.Username.ToLower() && x.Password == userlogin.Password);
                if (myuser != null)
                {
                    return myuser;
                }
                return null;
            }
            string Generate(User userlogin)
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, userlogin.Id.ToString()),
                new Claim(ClaimTypes.Name, userlogin.Username),
                new Claim(ClaimTypes.DateOfBirth, userlogin.Joindate.ToString()),
                new Claim(ClaimTypes.Role, userlogin.Role)
            };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
                claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials);

                var result = new JwtSecurityTokenHandler().WriteToken(token);
                return result;
            }
            return NotFound("User not found!!");
        }









    }
}