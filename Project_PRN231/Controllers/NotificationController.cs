using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_PRN231.Models;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        public readonly PRN231_SUContext db;
        public NotificationController(PRN231_SUContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificationByUserId(int Id)
        {
            try
            {
                var listNotifi = await db.Notifications.Where(x => x.UserId == Id).ToListAsync();
                foreach (var item in listNotifi)
                {
                    foreach (var i in db.NotificationCates.ToList())
                    {
                        if (i.Id == item.CateId)
                        {
                            item.Cate = i;
                        }
                    }
                }
                return Ok(listNotifi);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
