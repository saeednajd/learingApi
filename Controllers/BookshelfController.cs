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
    public class BookshelfController : ControllerBase
    {


        private readonly Libcontext _context;
        public BookshelfController(Libcontext context)
        {
            _context = context;
        }





        [HttpGet]


        public ActionResult<List<Bookshelf>> GetAllBookshelves()
        {

            var Bookshelf = _context.Bookshelves.ToList();
            return Bookshelf;
        }

        [HttpGet("{id}")]


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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]

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