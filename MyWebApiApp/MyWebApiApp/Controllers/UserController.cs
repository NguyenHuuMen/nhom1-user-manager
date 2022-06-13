using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User = MyWebApiApp.Data.User;



namespace MyWebApiApp.Controllers
{
   


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       /* public static List<User> Users = new List<User>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Users);
        } */

         

        private readonly DBContext userContext;

        public UserController(DBContext userContext)
        {
            this.userContext = userContext;
        }
        [HttpGet("getUser")]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await userContext.Users.ToListAsync());
        }

        



        [HttpPost("User")]
        public async Task<ActionResult<List<User>>> PostUser(User us)
        {
            
            var id = await userContext.Users.Where(a => a.userName == us.userName).SingleOrDefaultAsync();
            if (id == null)
            {
                userContext.Users.Add(us);
                await userContext.SaveChangesAsync();
                return Ok(us);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<User>> Put(User repuests)
        {
            var us = await userContext.Users.FindAsync(repuests.id);
            if (us == null)
                return NotFound();
            us.userName = repuests.userName;
            us.userPassword = repuests.userPassword;
            userContext.SaveChanges();
            return Ok(us);

        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var user = await userContext.Users.FindAsync(id)
;
            if (user == null)
                return BadRequest("Not found!");
            userContext.Users.Remove(user);
            userContext.SaveChanges();
            return Ok();
        }
        /*
         [HttpGet("{id}")]
         public IActionResult GetById(string id)
         {
             try
             {
                 // LINQ [Object] Query
                 var USer = Users.SingleOrDefault(us => us.Ma == Guid.Parse(id));
                 if (USer == null)
                 {
                     return NotFound();
                 }
                 return Ok(USer);
             }
             catch
             {
                 return BadRequest();
             }
         }

        /*
         [HttpPost]
         public IActionResult Create(UserVM USerVM)
         {
             var user = new User
             {
                 Ma = Guid.NewGuid(),
                 UserName = USerVM.UserName,
                 UserPassword = USerVM.UserPassword,
                 Phone = USerVM.Phone,
             };
             Users.Add(user);
             return Ok(new
             {
                 Success = true,
                 Data = user
             });
         }
        

         [HttpPut("{id}")]
         public IActionResult Edit(string id, User USerEdit)
         {
             try
             {
                 // LINQ [Object] Query
                 var USer = Users.SingleOrDefault(us => us.Ma == Guid.Parse(id));
                 if (User == null)
                 {
                     return NotFound();
                 }

                 if (id != USer.Ma.ToString())
                 {
                     return BadRequest();
                 }
                 // Update
                 USer.UserName = USerEdit.UserName;
                 USer.UserPassword = USerEdit.UserPassword;
                 USer.Phone = USerEdit.Phone;
                 return Ok();
             }
             catch
             {
                 return BadRequest();
             }
         }

         [HttpDelete("{id}")]
         public IActionResult Remove(string id)
         {
             try
             {
                 // LINQ [Object] Query
                 var USer = Users.SingleOrDefault(us => us.Ma == Guid.Parse(id));
                 if (USer == null)
                 {
                     return NotFound();
                 }
                 // Update
                 Users.Remove(USer);

                 return Ok();
             }
             catch
             {
                 return BadRequest();
             }
         }*/
        
        [HttpGet("{userName}")]
                 public async Task<ActionResult<List<User>>> GetUser(string userName)
                {
                    var user =  userContext.Users.Where(a => a.userName == userName).Single();

                    if (user == null)
                        return BadRequest("Not found!");
                    return Ok(user);

                }

        [HttpGet("login")]
        public async Task<ActionResult<List<User>>> getUserandPassword(string userName, string userPassword)
        {
            var user = await userContext.Users.Where(a =>
            a.userName == userName && a.userPassword == userPassword).SingleOrDefaultAsync();

            if (user == null)
                return BadRequest("Not found!");
            return Ok(user);

        }

    }

    

}