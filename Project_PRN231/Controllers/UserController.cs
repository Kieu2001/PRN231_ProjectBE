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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository user;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly PRN231_SUContext db;

        public UserController(IUserRepository trackRepository, IMapper mapper, IWebHostEnvironment env, PRN231_SUContext _db)
        {
            user = trackRepository;
            _mapper = mapper;
            _env = env;
            db = _db;
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Leader")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Writing")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Reporter")]
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
            var user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                foreach (var item in db.Roles.ToList())
                {
                    if (item.Id == user.RoleId)
                    {
                        user.Role = item;
                    }
                }
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> GetUserByEmail(string email, string fullname)
        {
            if (email != null)
            {
                var use = await db.Users.FirstOrDefaultAsync(x => x.Email == email);
                if (use == null)
                {
                    User a = new User
                    {
                        Email = email,
                        FullName = fullname,
                        CreateDate = DateTime.Now,
                        RoleId = 2
                    };
                    db.Users.Add(a);
                    await db.SaveChangesAsync();
                    return new JsonResult("Add new account");

                } 
                return new JsonResult("Already Exits");
            }
            return new JsonResult("");     
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
        public async Task<IActionResult> LoginByGoogleOrFaceBook(string email)
        {
            var use = await db.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (use == null)
            {
                
                return Ok();
            }
            return Ok(use);
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
        [HttpGet]
        public IActionResult DisplayImage(string fileName)
        {
            try
            {
                var physicalPath = Path.Combine(_env.ContentRootPath, "Photos", fileName);

                if (System.IO.File.Exists(physicalPath))
                {
                    return PhysicalFile(physicalPath, "image/jpeg"); // Thay đổi "image/jpeg" thành kiểu MIME phù hợp với ảnh của bạn
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
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
        [HttpGet]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var list = await db.Users.Where(x => x.Email.Contains(email)).ToListAsync();
            if (list != null)
            {
                foreach (var item in list)
                {
                    foreach (var i in db.Roles.ToList())
                    {
                        if (i.Id == item.RoleId)
                        {
                            item.Role = i;
                        }


                    }
                }
            }
            return Ok(list);
        }
    }
}
