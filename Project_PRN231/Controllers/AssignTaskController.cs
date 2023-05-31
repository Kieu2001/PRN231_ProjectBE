using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssignTaskController : ControllerBase
    {
        private readonly ILeaderReporitory assignTask;
        private readonly IMapper _mapper;

        public AssignTaskController(ILeaderReporitory trackRepository, IMapper mapper)
        {
            assignTask = trackRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllAssignTask()
        {
            IEnumerable<AssignTask> lstAssignTask = new List<AssignTask>();
            lstAssignTask = assignTask.GetAllAssignTask();
            return Ok(_mapper.Map<List<AssignTaskDTO>>(lstAssignTask));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAssignTaskById(int Id)
        {
            AssignTask aT = null;
            aT = assignTask.GetAssignTaskById(Id);
            if (aT == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AssignTaskDTO>(aT));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAssignTask(AssignTask assignTask)
        {
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAssignTask(AssignTask assignTask)
        {
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteAssignTask()
        {
            return Ok();
        }

    }
}
