using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapitwo.Model;

namespace webapitwo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Libraryetc(Libcontext context) : ControllerBase
    {
        private readonly Libcontext _context = context;




        [HttpGet]
        [Route("/api/[controller]/Users")]
        public ActionResult<List<User>> Allusersbybookstatus()
        {
            // var options = new JsonSerializerOptions
            // {
            //     ReferenceHandler = ReferenceHandler.Preserve
            // };
            var books = _context.Users.Include(x => x.Bookshelves)
            .ThenInclude(x => x.Book)
            .Where(x => x.Bookshelves.Any(x => x.Bookstatus != null))
            .Select(x => new
            {
                username = x.Username,
                bookstatuss = x.Bookshelves.Select(y => y.Bookstatus),

                booktitle = x.Bookshelves.Select(x => x.Book.Title)

            })
            .ToList();

            if (books == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(books));


            }
        }

        [HttpGet]
        [Route("/api/[controller]/{userid}/Users")]
        public ActionResult<List<User>> Oneuserbybookstatus(int userid)
        {

            var books = _context.Users.Include(x => x.Bookshelves)
            .ThenInclude(x => x.Book)
            .Where(x => x.Id == userid)
            .Where(x => x.Bookshelves.Any(x => x.Bookstatus != null))
            .Select(x => new
            {
                username = x.Username,
                bookstatuss = x.Bookshelves.Select(y => y.Bookstatus),

                booktitle = x.Bookshelves.Select(x => x.Book.Title)

            })
            .ToList();

            if (books == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(books));


            }
        }

        [HttpGet]
        [Route("/api/[controller]/Userscount")]
        public ActionResult<List<User>> Allusersreadedbookscount()
        {


            var users = _context.Users
            .Include(x => x.Bookshelves)
            .Select(x => new
            {
                username = x.Username,
                bookscount = x.Bookshelves.Count(y => y.Bookstatus == 1)
            }).ToList();


            if (users == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(users));

            }
        }


    }
}