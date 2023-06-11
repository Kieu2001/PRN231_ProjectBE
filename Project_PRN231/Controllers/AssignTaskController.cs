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
        private PRN231_SUContext db = new PRN231_SUContext();

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
            foreach (var item in lstAssignTask)
            {
                foreach (var i in db.Genres.ToList())
                {
                    if (item.GenreId == i.Id)
                    {
                        item.Genre = i;
                        break;
                    }
                }
            }
            return Ok(_mapper.Map<List<AssignTaskDTO>>(lstAssignTask));
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAssignTaskById(int Id)
        {
            AssignTask aT = null;
            aT = assignTask.GetAssignTaskById(Id);
            if (aT == null)
            {
                return NotFound();
            }
            foreach (var item in db.Genres.ToList())
            {
                if (item.Id == aT.GenreId)
                {
                    aT.Genre = item;
                    break;
                } 
            }
            return Ok(_mapper.Map<AssignTaskDTO>(aT));
        }

        [HttpGet]
        public IActionResult GetAssignTaskByReporterId(int reportId)
        {
            var lstAssignForRepoter = db.AssignTasks.Where(x => x.ReporterId == reportId).ToList();
            if (lstAssignForRepoter.Count == 0) 
            {
                return NotFound();  
            }
            return Ok(lstAssignForRepoter);
        }

        [HttpGet]
        public IActionResult GetAssignTaskByReporter()
        {
            return Ok(db.AssignTasks.Where(x => x.IsReportAccept == true).ToList());
        }

        [HttpGet]
        public IActionResult GetAssignTaskByWriter()
        {
            return Ok(db.AssignTasks.Where(x => x.IsWriterAccept == true).ToList());
        }

        [HttpGet]
        public IActionResult GetAllAssignTaskByWriterId(int writerId)
        {
            var lstAssignForWriter = db.AssignTasks.Where(x => x.WriterId == writerId).ToList();
            if (lstAssignForWriter.Count == 0)
            {
                return NotFound();
            }
            return Ok(lstAssignForWriter);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddAssignTask(AssignTask asTask)
        {
            assignTask.InsertAssignTask(asTask);
            return Ok("Insert Successfull!!!");
        }

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> UpdateAssignTask(AssignTask asTask)
        {
            var aT = assignTask.GetAssignTaskById(asTask.Id);
            if (aT == null)
            {
                return NotFound();
            } 
            assignTask.UpdateAssignTask(asTask);
            return Ok("Update Successfull!!!");
        }

        [HttpDelete]
        //[Authorize]
        public async Task<IActionResult> DeleteAssignTask(AssignTask asTask)
        {
            var aT = assignTask.GetAssignTaskById(asTask.Id);
            if (aT == null)
            {
                return NotFound();
            }
            assignTask.DeleteAssignTask(asTask);
            return Ok("Delete Successfull!!!");
        }

    }
}
