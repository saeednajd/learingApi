using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapitwo.Model;
namespace webapitwo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly Libcontext _context;
        public LibraryController(Libcontext context)
        {
            _context = context;
        }
        //users section
        [HttpGet]
        [Route("/api/[controller]/Users")]
        public ActionResult<List<User>> GetAllUsers()
        {

            var users = _context.Users.ToList();
            return users;
        }


        [HttpGet]
        [Route("/api/[controller]/{id}/Users")]

        public ActionResult<User> GetUser([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        //post

        [HttpPost]
        [Route("/api/[controller]/Users")]

        public ActionResult<User> AddUser(string username, string password)
        {
            var newuser = new User(username, password);
            _context.Users.Add(newuser);

            return CreatedAtAction(nameof(GetUser), new { id = newuser.Id }, newuser);
        }


        //books section

        [HttpGet]
        [Route("/api/[controller]/Books")]
        

        public ActionResult<List<Book>> GetAllBooks()
        {

            var books = _context.Books.ToList();
            return books;
        }

        [HttpGet]
        [Route("/api/[controller]/{id}/Books")]
        

        public ActionResult<Book> GetOneBook([FromRoute] int id)
        {

            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        [Route("/api/[controller]/Books")]

        public ActionResult<Book> Addbook(string Title, int pages)
        {
            var newbook = new Book(Title, pages);
            _context.Books.Add(newbook);

            return CreatedAtAction(nameof(GetUser), new { id = newbook.Id }, newbook);
        }

        
    }
}