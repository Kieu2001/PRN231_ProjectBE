using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdertisementController : Controller
    {
        private readonly IAdvertisementRepository Ad;
        private readonly IMapper _mapper;

        public AdertisementController(IAdvertisementRepository trackRepository, IMapper mapper)
        {
            Ad = trackRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAdertisementByAmount(long amount)
        {
            return Ok(Ad.GetAdByAmount(amount));
        }

    }
}
