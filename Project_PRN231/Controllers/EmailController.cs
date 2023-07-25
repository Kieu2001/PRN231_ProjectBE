using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.AspNetCore.Mvc;

namespace EmailAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailRequest request)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Team 9 - PRN231", "ngobacuong2211@gmail.com")); // Email nguồn
            message.To.Add(new MailboxAddress("", request.To)); // Email người nhận
            message.Subject = request.Subject; // Tiêu đề email

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = request.Text; // Nội dung email

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls); // SMTP server và port (ở đây sử dụng Gmail)
                client.Authenticate("ngobacuong2211@gmail.com", "utegedatcyktwyuj"); // Email nguồn và mật khẩu

                client.Send(message);
                client.Disconnect(true);
            }

            return Ok("Email sent successfully");
        }
    }

    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
