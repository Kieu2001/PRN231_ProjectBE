using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Models;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RejectTaskController : ControllerBase
    {
        public PRN231_SUContext db = new PRN231_SUContext();

        [HttpGet]
        public IActionResult GetAllRejectTaskAccept()
        {
            var listRejectTask = db.RejectTasks.Where(x => x.IsReject == true).ToList();
            if (listRejectTask.Count == 0)
            {
                return NotFound();
            }

            foreach (var item in listRejectTask)
            {
                foreach (var i in db.AssignTasks.ToList())
                {
                    if (item.TaskId == i.Id)
                    {
                        item.Task = i;
                        break;
                    }
                }
                foreach (var k in db.RejectGenres.ToList())
                {
                    if (k.Id == item.RejectId)
                    {
                        item.Reject = k;    
                    }
                }
                //foreach (var it in db.Users.ToList())
                //{
                //    if (item.UserId == it.Id)
                //    {
                //        item.User = it;
                //    }
                //}
            }
            return Ok(listRejectTask);
        }

        [HttpGet]
        public IActionResult GetAllRejectTaskPending() 
        {
            var listPending = db.RejectTasks.Where(x => x.IsReject == false && x.RejectId == 1).ToList();
            if (listPending.Count == 0)
            {
                return NotFound();  
            }

            foreach (var item in listPending)
            {
                foreach (var i in db.AssignTasks.ToList())
                {
                    if (item.TaskId == i.Id)
                    {
                        item.Task = i;
                        break;
                    }
                }

                //foreach (var it in db.Users.ToList())
                //{
                //    if (item.UserId == it.Id)
                //    {
                //        item.User = it;
                //    }
                //}
            }
            return Ok(listPending);
        }

        [HttpPost]
        public IActionResult AddRejectTask(RejectTask rejectTask)
        {
            rejectTask.IsReject = false;
            if (rejectTask.TaskId == 0 || rejectTask.UserId == 0 || rejectTask.Reason == "")
            {
                return BadRequest();
            } 
            db.RejectTasks.Add(rejectTask);
            db.SaveChanges();
            return Ok("Insert Successfull!!!");
        }

        [HttpPut]
        public IActionResult UpdateRejectTask(RejectTask rejectTask)
        {
            var rt = db.RejectTasks.FirstOrDefault(x => x.Id == rejectTask.Id);
            if (rt == null) 
            {
                return NotFound();
            }
            rt.IsReject = rejectTask.IsReject;
            db.Entry<RejectTask>(rt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Ok("Update Successfull!!!");
        }

        [HttpDelete] 
        public IActionResult DeleteRejectTask(int Id)
        {
            var rT = db.RejectTasks.FirstOrDefault(x => x.Id == Id);
            if (rT == null)
            {
                return NotFound();
            }
            db.RejectTasks.Remove(rT);
            db.SaveChanges();
            return Ok("Delete Succcessfull!!!");
        }
    }
}
