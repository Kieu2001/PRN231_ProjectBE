using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository user;
        private readonly IMapper _mapper;

        public UserController(IUserRepository trackRepository, IMapper mapper)
        {
            user = trackRepository;
            _mapper = mapper;
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
            return Ok(user.GetUserById(id));
        }
        [HttpGet]
        public IActionResult GetUserRole(int id)
        {
            return Ok(user.GetUserRole(id));
        }

        [HttpPost]
        public IActionResult InsertUser(User use)
        {
            user.InsertUser(use);
            return Ok("Inserted Successfull!!!");
        }

    }
}
