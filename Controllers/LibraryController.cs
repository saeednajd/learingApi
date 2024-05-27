using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using thirdapi.Model.Dtos;
using webapitwo.Model;
namespace webapitwo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {

        //identity injections
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        //other injections
        private readonly IConfiguration _configure;
        private readonly Libcontext _context;
        public LibraryController(Libcontext context, UserManager<User> userManager,
         RoleManager<IdentityRole> roleManager, IConfiguration configure,
         SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configure = configure;
            _signInManager = signInManager;
        }
        //users section
        [HttpGet]
        [Route("/api/[controller]/Users")]
        [Authorize(Roles = "Admin")]

        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }
        [HttpGet]
        [Route("/api/[controller]/{id}/Users")]
        public ActionResult<User> GetUser([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(x => Int32.Parse(x.Id) == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        //post
        [HttpPost]
        [Route("/api/[controller]/Users")]
        public async Task<IActionResult> NewUser(Userdto userdata, string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                return BadRequest($"Role {role} does not exist.");
            }

            var user = new User
            {
                UserName = userdata.username,
                Id = userdata.Id,
            };

            var result = await _userManager.CreateAsync(user, userdata.password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
            if (!addToRoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return BadRequest(addToRoleResult.Errors);
            }

            return Ok("User created successfully");
        }


        //log in 

        [HttpPost]
        [Route("/api/[controller]/Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return BadRequest("Invalid username or password.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return BadRequest("Invalid username or password.");
            }

            return Ok("Login successful");
        }


        [HttpPost]
        [Route("/api/[controller]/addingroletouser")]
        public async Task<IActionResult> Addingroletoauser(Userdto userdata, string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid inputes !!");

            }
            var validrole = await _roleManager.RoleExistsAsync(role);
            if (!validrole)
            {
                return BadRequest("Invalid role");
            }
            var myuser = _userManager.FindByNameAsync(userdata.username);
            if (myuser == null)
            {
                return BadRequest("user not found");
            }
            var result = await _userManager.AddToRoleAsync(myuser.Result, role);
            if (!result.Succeeded)
            {
                return BadRequest("role could't add");
            }


            return Ok("Role added to user successfuly");
        }





        // [HttpPost]
        // [Route("/api/[controller]/Users")]

        // public async Task<ActionResult<string>> AddUser(string username, string password)
        // {

        //     var myuser = await _userManager.FindByIdAsync(username);
        //     IdentityUser user = new(){
        //         UserName = username,

        //     }
        //     var newuser = new User(username, password);
        //     _context.Users.Add(newuser);
        //     _context.SaveChanges();

        //     return CreatedAtAction(nameof(GetUser), new { id = newuser.Id }, newuser);
        // }


        // //books section

        // [HttpGet]
        // [Route("/api/[controller]/Books")]


        // public ActionResult<List<Book>> GetAllBooks()
        // {

        //     var books = _context.Books.ToList();
        //     return books;
        // }

        // [HttpGet]
        // [Route("/api/[controller]/{id}/Books")]


        // public ActionResult<Book> GetOneBook([FromRoute] int id)
        // {

        //     var book = _context.Books.FirstOrDefault(x => x.Id == id);
        //     if (book == null)
        //     {
        //         return NotFound();
        //     }
        //     return book;
        // }

        // [HttpPost]
        // [Route("/api/[controller]/Books")]

        // public ActionResult<Book> Addbook(string Title, int pages)
        // {
        //     var newbook = new Book(Title, pages);
        //     _context.Books.Add(newbook);
        //     _context.SaveChanges();

        //     return CreatedAtAction(nameof(GetUser), new { id = newbook.Id }, newbook);
        // }


        // // shelf section


        // [HttpGet]
        // [Route("/api/[controller]/Shelf")]


        // public ActionResult<List<Shelf>> GetAllShelves()
        // {

        //     var Shelf = _context.Shelves.ToList();
        //     return Shelf;
        // }


        // [HttpGet]
        // [Route("/api/[controller]/{id}/Shelf")]


        // public ActionResult<Shelf> GetOneShelf([FromRoute] int id)
        // {

        //     var shelf = _context.Shelves.FirstOrDefault(x => x.Id == id);
        //     if (shelf == null)
        //     {
        //         return NotFound();
        //     }
        //     return shelf;
        // }

        // [HttpPost]
        // [Route("/api/[controller]/Shelf")]

        // public ActionResult<Shelf> AddShelf(string name)
        // {
        //     var newshelf = new Shelf(name);
        //     _context.Shelves.Add(newshelf);
        //     _context.SaveChanges();

        //     return CreatedAtAction(nameof(GetUser), new { id = newshelf.Id }, newshelf);
        // }

        // //////////////////////// Bookshelf section

        // [HttpGet]
        // [Route("/api/[controller]/Bookshelf")]


        // public ActionResult<List<Bookshelf>> GetAllBookshelves()
        // {

        //     var Bookshelf = _context.Bookshelves.ToList();
        //     return Bookshelf;
        // }

        // [HttpGet]
        // [Route("/api/[controller]/{id}/Bookshelf")]


        // public ActionResult<Bookshelf> GetOneBookshelf([FromRoute] int id)
        // {

        //     var Bookshelf = _context.Bookshelves.FirstOrDefault(x => x.Id == id);
        //     if (Bookshelf == null)
        //     {
        //         return NotFound();
        //     }
        //     return Bookshelf;
        // }

        // [HttpPut]
        // [Route("/api/[controller]/{bookshelfid}/{bookstatus}/Bookshelf")]

        // public ActionResult<Bookshelf> Changebookstatus([FromRoute] int bookshelfid, int bookstatus)
        // {

        //     var mybookshelf = _context.Bookshelves.FirstOrDefault(x => x.Id == bookshelfid);



        //     if (mybookshelf == null)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {

        //         //update method for bookshelf status
        //         mybookshelf.UpdateStatus(bookstatus);

        //         _context.Update(mybookshelf);
        //         _context.SaveChanges();

        //         return Ok(mybookshelf);
        //     }




        // }


        // [HttpPost]
        // [Route("/api/[controller]/Bookshelf")]

        // public ActionResult<Bookshelf> AddBookshelf([FromRoute] int bookshelfid, int userids, int bookid, int shelfid, int bookstatus)
        // {

        //     Bookshelf newBookshelf = new(bookstatus: bookstatus, userid: userids, bookid: bookid, shelfid: shelfid);

        //     // var newBookshelf = new Bookshelf(bookstatus, userids, bookid, shelfid);
        //     _context.Bookshelves.Add(newBookshelf);
        //     _context.SaveChanges();
        //     return CreatedAtAction(nameof(GetOneBookshelf), new { id = newBookshelf.Id }, newBookshelf);
        // }



    }

}
