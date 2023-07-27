using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_PRN231.DataAccess;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdertisementOrderController : Controller
    {

        private readonly IAdvertisementOrderRepository AdOrder;
        private readonly IMapper _mapper;
        private readonly PRN231_SUContext db;

        public AdertisementOrderController(IAdvertisementOrderRepository trackRepository, IMapper mapper, PRN231_SUContext db)
        {
            AdOrder = trackRepository;
            _mapper = mapper;
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetAdertisementOrderById(int id)
        {
            return Ok(AdOrder.GetAdvertisementOrderById(id));
        }

        [HttpGet]
        public async Task<IActionResult> AdvertisRandom()
        {
            var order = await db.AdvertisementOrders.Where(x => x.IsPending == true && x.IsApprove == true && (x.IsDelete == false || x.IsDelete == null)).ToListAsync();
            Random random = new Random();
            int randomNumber = random.Next(1, 11);
            if (randomNumber <= 7)
            {
                foreach (var item in order)
                {
                    if (item.AdvertisementId == 2)
                    {
                        return Ok(item);
                    }
                }
            } else
            {
                foreach (var item in order)
                {
                    if (item.AdvertisementId == 1)
                    {
                        return Ok(item);
                    }
                }
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderAdvertisAccept()
        {
            var listOrder = await db.AdvertisementOrders.Where(x => x.IsPending == true && x.IsApprove == true && (x.IsDelete == false || x.IsDelete == null)).ToListAsync();
            foreach (var order in listOrder) 
            {
                foreach (var item in db.Advertisements.ToList())
                {
                    if (item.Id == order.AdvertisementId)
                    {
                        order.Advertisement = item;
                        break;
                    }
                }

                foreach (var item in db.Users.ToList())
                {
                    if (item.Id == order.UserId)
                    {
                        order.User = item;
                        break;
                    }
                }
            }
            return Ok(listOrder);
        }

        [HttpGet]
        public IActionResult GetAdertisementOrderByApprove()
        {
            var lstUser = AdOrder.GetAdOrderByApprove();
            return Ok(lstUser);
        }

        [HttpGet]
        public IActionResult GetAdertisementOrderByDate(DateTime date)
        {
            return Ok(AdOrder.GetAdOrderByOrder(date));
        }
        [HttpPost]
        public IActionResult InsertAdvertisementOrder(AdvertisementOrder advertisementOrder)
        {
            AdOrder.InsertAdvertisementOrder(advertisementOrder);
            return Ok("Inserted Successfull!!!");
        }

        [HttpPost("isPending/{adId}")]
        public IActionResult UpdateIsPending(int adId)
        {
            try
            {
                var adOrder = AdOrder.GetAdvertisementOrderById(adId);
                if (adOrder == null)
                {
                    return NotFound("Advertisement order not found");
                }

                adOrder.IsPending = true;
                AdOrder.UpdateAdvertisementOrder(adOrder);

                return Ok("isPending updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("isApprove/{adId}")]
        public IActionResult UpdateIsApprove(int adId)
        {
            try
            {
                var adOrder = AdOrder.GetAdvertisementOrderById(adId);
                if (adOrder == null)
                {
                    return NotFound("Advertisement order not found");
                }

                adOrder.IsApprove = true;
                AdOrder.UpdateAdvertisementOrder(adOrder);
                return Ok("isApprove updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> CheckDeadLine(int taskId)
        {
            var order = await db.AdvertisementOrders.FirstOrDefaultAsync(x => x.Id == taskId);
            order.IsDelete = true;
            db.Entry<AdvertisementOrder>(order).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return new JsonResult("");
        }


        [HttpDelete]
        public IActionResult DeleteAdvertisementOrder(int id)
        {
            var g = AdOrder.GetAdvertisementOrderById(id);
            if (g == null)
            {
                return NotFound();
            }
            AdOrder.DeletetAdvertisementOrder(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAdertisementOrderByUser(int userId)
        {
            return Ok(AdOrder.advertisementOrdersByUserId(userId));
        }
    }

}

