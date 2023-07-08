using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WritingTaskController : ControllerBase
    {
        private readonly IWriterRepository writerRepository;
        public PRN231_SUContext db = new PRN231_SUContext();
        private readonly IWebHostEnvironment _env;
        public WritingTaskController(IWriterRepository _writerRepository, IWebHostEnvironment env)
        {
            writerRepository = _writerRepository;
            _env = env;
        }
        [HttpGet]
        public IActionResult GetAllWritingTask()
        {
            var listWritingTask = writerRepository.GetAllWritingTask();
            foreach (var item in listWritingTask)
            {
                foreach (var i in db.AssignTasks.ToList())
                {
                    if (i.Id == item.TaskId)
                    {
                        foreach (var k in db.Genres.ToList())
                        {
                            if (k.Id == i.GenreId)
                            {
                                i.Genre = k;
                            }
                        }
                        item.Task = i;
                        break;
                    }
                }
            }
            return Ok(listWritingTask);
        }

        [HttpGet]
        public async Task<IActionResult> GetWritingByUserId(int Id)
        {
            try
            {
                return Ok(writerRepository.GetWritingTasksByUserId(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult GetWritingTaskById(int Id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetWritingTaskByTaskId(int taskId)
        {
            var wT = db.WritingTasks.FirstOrDefault(x => x.TaskId == taskId);
            if (wT == null)
            {
                return NotFound();
            }
            foreach (var item in db.AssignTasks.ToList())
            {
                if (item.Id == wT.TaskId)
                {
                    wT.Task = item;
                }
            }

            return Ok(wT);
        }

        [HttpPost]
        public IActionResult InsertWritingTask(WritingTask writingTask)
        {
            writerRepository.InsertWritingTask(writingTask);
            return Ok("Insert Successfull!!!");
        }

        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        public class UpdateContentWritingTask
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Content { get; set; }
            public string Image { get; set; }
            public string Comment { get; set; }
            public bool IsChecked { get; set; }
        }

        [HttpPut]
        public IActionResult UpdateWritingTask(UpdateContentWritingTask writingTask)
        {
            try
            {
                var wT = writerRepository.GetWritingTaskById(writingTask.Id);
                if (wT == null)
                {
                    return NotFound();
                }
                wT.Title = writingTask.Title;
                wT.Id = writingTask.Id;
                wT.Description = writingTask.Description;
                wT.Content = writingTask.Content;
                wT.Image = writingTask.Image;
                wT.Comment = writingTask.Comment;
                wT.IsChecked = writingTask.IsChecked;
                writerRepository.UpdateWritingTask(wT);
                return Ok("Update Successfull!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> CheckDeadLine(int taskId, string IsLated)
        {
            var task = await db.WritingTasks.FirstOrDefaultAsync(x => x.Id == taskId);
            if (task != null)
            {
                try
                {
                    if (IsLated == "true")
                    {
                        task.IsLated = true;
                    }
                    db.Entry<WritingTask>(task).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok("Update Successfull!!!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> DeleteWritingTask(int Id)
        {
            var writingTask = writerRepository.GetWritingTaskById(Id);
            if (writingTask == null)
            {
                return NotFound();
            }
            try
            {
                writingTask.IsDeleted = true;
                db.Entry<WritingTask>(writingTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok("Delete Successfull!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
