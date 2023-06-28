using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public IActionResult InsertAdvertisementOrder(AdvertisementOrder advertisementOrder)
        {
            AdOrder.InsertAdvertisementOrder(advertisementOrder);
            return Ok("Inserted Successfull!!!");
        }

    }
}
