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
    public class ShelfController : ControllerBase
    {

        private readonly Libcontext _context;
        public ShelfController(Libcontext context)
        {
            _context = context;
        }

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

        [HttpPost("Shelf")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Shelf> AddShelf(string name)
        {
            var newshelf = new Shelf(name);
            _context.Shelves.Add(newshelf);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOneShelf), new { id = newshelf.Id });
        }
    }
}