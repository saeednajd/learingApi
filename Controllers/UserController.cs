// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using webapitwo.Model;
// namespace webapitwo.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class UserController : ControllerBase
//     {

//         private readonly Libcontext _context;
//         public UserController(Libcontext context)
//         {
//             _context = context;
//         }

//         [HttpGet]
//         public ActionResult<List<User>> GetAll()
//         {

//             var users = _context.Users.ToList();
//             return users;
//         }

//         // GET by Id action
//         [HttpGet("{id}")]
//         public ActionResult<User> Get(int id)
//         {
//             var user = _context.Users.FirstOrDefault(x => x.Id == id);
//             return user;
//         }




//         // POST action

//         [HttpPost]
//         public IActionResult Create(string username, string password)
//         {
//             var newuser = new User(username, password);

//             _context.Users.Add(newuser);
//             _context.SaveChanges();
//             return CreatedAtAction(nameof(Get), new { id = newuser.Id }, newuser);
//         }
//         // [HttpPost]
//         // public IActionResult Create(Pizza pizza)
//         // {
//         //     PizzaService.Add(pizza);
//         //     return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
//         // }
//         // // PUT action
//         // [HttpPut("{id}")]
//         // public IActionResult Update(int id, Pizza pizza)
//         // {
//         //     if (id != pizza.Id)
//         //         return BadRequest();

//         //     var existingPizza = PizzaService.Get(id);
//         //     if (existingPizza is null)
//         //         return NotFound();

//         //     PizzaService.Update(pizza);

//         //     return NoContent();
//         // }
//         // // DELETE action
//         // [HttpDelete("{id}")]
//         // public IActionResult Delete(int id)
//         // {
//         //     var pizza = PizzaService.Get(id);

//         //     if (pizza is null)
//         //         return NotFound();

//         //     PizzaService.Delete(id);

//         //     return NoContent();
//         // }
//     }
// }