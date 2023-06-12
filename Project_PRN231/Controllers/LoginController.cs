using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly PRN231_SUContext db;
        public LoginController(IConfiguration config,PRN231_SUContext _db)
        {
            _config = config;
            db= _db;
        }
        private User AuthenticateUser(string email,string password)
        {
            User _user = db.Users.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));

            return _user;
        }

        //private string GenerateToken(User user)
        //{
        //    var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
        //        expires: DateTime.Now.AddMinutes(1),
        //        signingCredentials: credentials
        //        );
        //    return new JwtSecurityTokenHandler().WriteToken(token);

        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login(string email, string password)
        //{
        //    IActionResult response = Unauthorized();
        //    var user_ = AuthenticateUser(email, password);
        //    if (user_ != null)
        //    {
        //        var token = GenerateToken(user_);
        //        response = Ok(new { token = token });
        //    }
        //    return response;
        //}

       
        [HttpPost()]
        public IActionResult Login(LoginDTO login)
        {
            try
            {
               
                // Kiểm tra thông tin đăng nhập
                if (AuthenticateUser(login.Email, login.Password) != null)
                {
                    User user = db.Users.Where(x => x.Email.Equals(login.Email)).SingleOrDefault();
                    Role role = db.Roles.Where(u => u.Id == user.RoleId).SingleOrDefault();

                    // Tạo danh sách các claim
                    var claims = new[]
                    {
                new Claim("Id", user.Id.ToString()),
                new Claim("roleId", user.RoleId.ToString()),
                new Claim("FullName", user.FullName),
                new Claim("Role_Name",role.RoleName),
               
                // Thêm các claim khác tùy ý
            };

                    // Tạo token
                    var token = GenerateToken(claims);

                    return Ok(new { token });
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           

            return Unauthorized();
        }


        private string GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
