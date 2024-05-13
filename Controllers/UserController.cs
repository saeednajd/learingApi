using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thirdapi.Model;
using webapitwo.Model;
using learingApi.Tools;
namespace webapitwo.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Libcontext _context;
        public UserController(Libcontext context)
        {
            _context = context;
        }


        // private Userdto Getcorrentuser()
        // {
        //     var identity = HttpContext.User.Identity as ClaimsIdentity;
        //     var userclaims = identity.Claims;
        //     var correntuser = new Userdto
        //     {
        //         Id = Convert.ToInt32(userclaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
        //         Username = Convert.ToString(userclaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value),
        //         Joindate = Convert.ToDateTime(userclaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
        //         Role = Convert.ToString(userclaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value)
        //     };
        //     return correntuser;
        // }
        //users section
        [HttpGet]
        [Route("/api/[controller]/Users")]
        [Authorize(Roles = "Admin")]

        public ActionResult<List<Userdto>> GetAllUsers()
        {

            var users = _context.Users.Select(x => new Userdto
            {
                Id = x.Id,
                Username = x.Username,
                Joindate = x.Joindate

            }).ToList();

            return users;
        }



        [HttpGet]
        [Route("/api/[controller]/{id}/Users")]
        [Authorize(Roles ="Admin")]
        public ActionResult<Userdto> GetUser([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var myuser = new Userdto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Joindate = user.Joindate
            };

            return myuser;
        }
        //post




        [HttpPost]
        [Route("/api/[controller]/Users")]
        // [Authorize(Roles ="Admin")]

        public ActionResult<User> AddUser(string username, string password, string role)
        {
            var hashedpass = Passwordhasher.Hashpass(password);
            var newuser = new User(username, hashedpass, role);
            _context.Users.Add(newuser);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = newuser.Id }, newuser);
        }
    }

}
