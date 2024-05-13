using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapitwo;
using webapitwo.Model;

namespace learingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {


        private readonly Libcontext _context;

        public BookController(Libcontext context)
        {
            _context = context;
        }

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

        [HttpPost("Books")]
        // [Route("/api/[controller]/Books")]

        [Authorize(Roles = "Admin")]

        public ActionResult<Book> Addbook(string Title, int pages)
        {
            var newbook = new Book(Title, pages);
            _context.Books.Add(newbook);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOneBook), new { id = newbook.Id }, newbook);
        }
    }
}