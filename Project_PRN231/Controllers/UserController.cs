using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Project_PRN231.DataAccess;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;
using System.Net;
using System.Reflection.Metadata;
using System;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository user;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public UserController(IUserRepository trackRepository, IMapper mapper, IWebHostEnvironment env)
        {
            user = trackRepository;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var lstUser = user.GetAllUser();
            return Ok(lstUser);
        }

 
        [HttpGet]
        public IActionResult GetAllUserBan(bool Ban)
        {
            var lstUser = user.GetUserListBan(Ban);
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

        [HttpPost]
        public JsonResult ImportFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(fileName);

            }
            catch (Exception ex)
            {
                return new JsonResult("");
            }
        }


        [HttpPut]
        public IActionResult UpdateBanStatus(int id, [FromBody] bool isBan)
        {
            try
            {

                User g = user.GetUserById(id);

                if (g != null)
                {

                    g.IsBan = isBan;
                    user.UpdateUser(g);
                    return Ok();
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult GetUserData(int numberOfDays)
        {
            try
            {
                int userDataCount = UserManagement.Instance.GetUserData(numberOfDays);
                return Ok(userDataCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }


}

