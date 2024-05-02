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


        [HttpPost]
        [Route("/api/[controller]/Bookshelf")]

        public ActionResult<Bookshelf> AddBookshelf(int Bookstatus)
        {
            var newBookshelf = new Bookshelf(Bookstatus);
            _context.Bookshelves.Add(newBookshelf);

            return CreatedAtAction(nameof(GetUser), new { id = newBookshelf.Id }, newBookshelf);
        }


        // bookshelf put section

        // [HttpPut]
        // [Route("/api/[controller]/Bookshelf")]

        // public ActionResult<Bookshelf> UpdateBookshelf([FromBody] int bookshelfid,int userid, int bookid, int shelfid, int bookstatus)
        // {

        //     var mybookshelf = _context.Bookshelves.Find(bookshelfid);

        //     var newbooshelfandshelf = new Bookshelfandshelf(mybookshelf.Id, shelfid);

            
        //     var shelfToUpdate = _context.Shelves.FirstOrDefault(s => s.Id == shelfid);
        //     if (shelfToUpdate != null)
        //     {
        //         shelfToUpdate.Bookshelfandshelfid= newbooshelfandshelf.Id;
        //         _context.SaveChanges();
        //     }
        //     else{
        //         return NotFound();
        //     }

            
        // }
    }

}
