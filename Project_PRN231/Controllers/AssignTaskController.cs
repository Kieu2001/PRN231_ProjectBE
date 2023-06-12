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
            var lstAssignForRepoter = db.AssignTasks.Where(x => x.ReporterId == reportId && x.IsReportAccept == false).ToList();
            if (lstAssignForRepoter.Count == 0) 
            {
                return NotFound();  
            }
            foreach (var item in lstAssignForRepoter)
            {
                foreach (var i in db.Users.ToList())
                {
                    if (item.ReporterId == i.Id)
                    {
                        item.Reporter = i;
                    }

                    if (item.LeaderId == i.Id)
                    {
                        item.Leader = i;
                    }

                    if (item.WriterId == i.Id)
                    {
                        item.Writer = i;
                    }
                }

                foreach (var k in db.Genres.ToList())
                {
                    if (item.GenreId == k.Id)
                    {
                        item.Genre = k;
                    }
                }
            }
            return Ok(lstAssignForRepoter);
        }

        [HttpGet]
        public IActionResult GetAllAssignTaskByWriterId(int writerId)
        {
            var lstAssignForWriter = db.AssignTasks.Where(x => x.WriterId == writerId && x.IsWriterAccept == false).ToList();
            if (lstAssignForWriter.Count == 0)
            {
                return NotFound();
            }
            foreach (var item in lstAssignForWriter)
            {
                foreach (var i in db.Users.ToList())
                {
                    if (item.ReporterId == i.Id)
                    {
                        item.Reporter = i;
                    }

                    if (item.LeaderId == i.Id)
                    {
                        item.Leader = i;
                    }

                    if (item.WriterId == i.Id)
                    {
                        item.Writer = i;
                    }
                }

                foreach (var k in db.Genres.ToList())
                {
                    if (item.GenreId == k.Id)
                    {
                        item.Genre = k;
                    }
                }
            }
            return Ok(lstAssignForWriter);
        }

        public class AccecptTask
        {
            public int? Id { get; set; }
            public string? UserStatus { get; set; }
            public bool IsStatus { get; set; } 
        }

        [HttpPut]
        public IActionResult AcceptTask(AccecptTask accecptTask)
        {
            AssignTask? aT = db.AssignTasks.FirstOrDefault(x => x.Id == accecptTask.Id);
            if (aT == null)
            {
                return NotFound();
            }
            if (accecptTask.UserStatus.Equals("Reporter"))
            {
                aT.IsReportAccept = true;
            } else
            {
                aT.IsWriterAccept = true;
            }

            db.Entry<AssignTask>(aT).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Ok("Update Successfull!!!");
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
