using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public AdertisementOrderController(IAdvertisementOrderRepository trackRepository, IMapper mapper)
        {
            AdOrder = trackRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAdertisementOrderById(int id)
        {
            return Ok(AdOrder.GetAdvertisementOrderById(id));
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

