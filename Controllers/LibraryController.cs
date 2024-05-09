using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thirdapi.Model;
using webapitwo.Model;
namespace webapitwo.Controllers
{

    // public class User(string UserName);

    // public record User2(string UserName);


    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly Libcontext _context;
        public LibraryController(Libcontext context)
        {
            _context = context;
        }


        private Userdto Getcorrentuser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userclaims = identity.Claims;
            var correntuser = new Userdto
            {
                Id = Convert.ToInt32(userclaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
                Username = Convert.ToString(userclaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value),
                Joindate = Convert.ToDateTime(userclaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
                Role =Convert.ToString(userclaims.FirstOrDefault(x=>x.Type==ClaimTypes.Role)?.Value)
            };
            return correntuser;
        }
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

        public ActionResult<Book> AddUser(string username, string password,string role)
        {
            var newuser = new User(username, password, role);
            _context.Users.Add(newuser);
            _context.SaveChanges();

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
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = newbook.Id }, newbook);
        }


        // shelf section


        [HttpGet]
        [Route("/api/[controller]/Shelf")]


        public ActionResult<List<Shelf>> GetAllShelves()
        {

            var Shelf = _context.Shelves.ToList();
            return Shelf;
        }


        [HttpGet]
        [Route("/api/[controller]/{id}/Shelf")]


        public ActionResult<Shelf> GetOneShelf([FromRoute] int id)
        {

            var shelf = _context.Shelves.FirstOrDefault(x => x.Id == id);
            if (shelf == null)
            {
                return NotFound();
            }
            return shelf;
        }

        [HttpPost]
        [Route("/api/[controller]/Shelf")]

        public ActionResult<Shelf> AddShelf(string name)
        {
            var newshelf = new Shelf(name);
            _context.Shelves.Add(newshelf);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = newshelf.Id }, newshelf);
        }

        //////////////////////// Bookshelf section

        [HttpGet]
        [Route("/api/[controller]/Bookshelf")]


        public ActionResult<List<Bookshelf>> GetAllBookshelves()
        {

            var Bookshelf = _context.Bookshelves.ToList();
            return Bookshelf;
        }

        [HttpGet]
        [Route("/api/[controller]/{id}/Bookshelf")]


        public ActionResult<Bookshelf> GetOneBookshelf([FromRoute] int id)
        {

            var Bookshelf = _context.Bookshelves.FirstOrDefault(x => x.Id == id);
            if (Bookshelf == null)
            {
                return NotFound();
            }
            return Bookshelf;
        }

        [HttpPut]
        [Route("/api/[controller]/{bookshelfid}/{bookstatus}/Bookshelf")]

        public ActionResult<Bookshelf> Changebookstatus([FromRoute] int bookshelfid, int bookstatus)
        {

            var mybookshelf = _context.Bookshelves.FirstOrDefault(x => x.Id == bookshelfid);



            if (mybookshelf == null)
            {
                return NotFound();
            }
            else
            {

                //update method for bookshelf status
                mybookshelf.UpdateStatus(bookstatus);

                _context.Update(mybookshelf);
                _context.SaveChanges();

                return Ok(mybookshelf);
            }




        }


        [HttpPost]
        [Route("/api/[controller]/Bookshelf")]

        public ActionResult<Bookshelf> AddBookshelf([FromRoute] int bookshelfid, int userids, int bookid, int shelfid, int bookstatus)
        {

            Bookshelf newBookshelf = new(bookstatus: bookstatus, userid: userids, bookid: bookid, shelfid: shelfid);

            // var newBookshelf = new Bookshelf(bookstatus, userids, bookid, shelfid);
            _context.Bookshelves.Add(newBookshelf);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOneBookshelf), new { id = newBookshelf.Id }, newBookshelf);
        }



    }

}
