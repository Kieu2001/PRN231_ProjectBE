using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository user;
        private readonly IMapper _mapper;
        private readonly PRN231_SUContext db;

        public UserController(IUserRepository trackRepository, IMapper mapper, PRN231_SUContext db)
        {
            user = trackRepository;
            _mapper = mapper;
            this.db= db;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var lstUser = user.GetAllUser();
            return Ok(lstUser);
        }

        [HttpGet]
        public IActionResult GetUserById(int id)
        {

            var u = user.GetUserById(id);
            foreach (var item in db.Roles.ToList())
            {
                if (item.Id == u.RoleId)
                {
                    u.Role = item; 
                    break;
                }
            }
            return Ok(u);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await db.Users.Where(x => x.Email.Contains(email)).ToListAsync();
            
            if (user == null)
            {
                return NotFound();
            }
            
            foreach (var item in db.Roles.ToList())
            {
                foreach (var i in user)
                {
                    if (i.RoleId == item.Id)
                    {
                        i.Role = item;
                        break;
                    }
                }
            }
            return Ok(user);
        }
        //[HttpGet]
        //public IActionResult GetUserRole(int id)
        //{
        //    return Ok(user.GetUserRole(id));
        //}

        [HttpPost]
        public IActionResult InsertUser(User use)
        {
            user.InsertUser(use);
            return Ok("Inserted Successfull!!!");
        }

    }
}
