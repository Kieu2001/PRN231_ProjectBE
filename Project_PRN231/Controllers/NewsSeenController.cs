using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ess;
using Project_PRN231.Models;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsSeenController : ControllerBase
    {
        public readonly PRN231_SUContext db;
        public NewsSeenController(PRN231_SUContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewsSeen(NewsSeen newsSeen)
        {
            try
            {
                var a = await db.NewsSeens.FirstOrDefaultAsync(x => x.UserId == newsSeen.UserId && x.NewsId == newsSeen.NewsId && x.CateId == newsSeen.CateId);
                if (a == null)
                {
                    db.NewsSeens.Add(newsSeen);
                    await db.SaveChangesAsync();
                    return new JsonResult("Add Successfull");
                }
                return new JsonResult("Allready exist!!!");
            } catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewsSave(NewsSeen newsSave)
        {
            try
            {
                var a = await db.NewsSeens.FirstOrDefaultAsync(x => x.UserId == newsSave.UserId && x.NewsId == newsSave.NewsId && x.CateId == newsSave.CateId);
                if (a == null)
                {
                    db.NewsSeens.Add(newsSave);
                    await db.SaveChangesAsync();
                    return new JsonResult("Add Successfull!!!");
                }
                return new JsonResult("Allreadt Exist");
            } catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListNews(int userId, int rateId)
        { 
            var listNews = await db.NewsSeens.Where(x => x.UserId == userId).ToListAsync();
            if (rateId == 1)
            {
                listNews = listNews.Where(x => x.CateId == 1).ToList();
            }
           
            if (rateId == 2)
            {
                listNews = listNews.Where(x => x.CateId == 2).ToList();
            }
            return Ok(listNews);
        }
    }
}
