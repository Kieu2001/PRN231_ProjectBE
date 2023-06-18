using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;
using System.Net.WebSockets;
using X.PagedList;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WritingTaskController : ControllerBase
    {
        private readonly IWriterRepository writerRepository;
        private readonly IWebHostEnvironment _env;
        public PRN231_SUContext db = new PRN231_SUContext();
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
                        item.Task = i;
                        break;
                    }
                }
            }

            foreach (var item in listWritingTask)
            {
                foreach (var i in db.Genres.ToList())
                {
                    if (item.Task.GenreId == i.Id)
                    {
                        item.Task.Genre = i;
                    }
                }
            }
            return Ok(listWritingTask);
        }

        [HttpGet]
        public IActionResult GetWritingTaskById(int Id)
        {
            var task = writerRepository.GetWritingTaskById(Id);
            return Ok(task);
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
                    break;
                }
            }

            //foreach (var item in db.Users.ToList())
            //{
            //    if (item.Id == wT.UserId)
            //    {
            //        wT.User = item;
            //        break;
            //    }
            //}

            

            return Ok(wT);
        }

        [HttpPost]
        public IActionResult InsertWritingTask(WritingTask writingTask)
        {
            writerRepository.InsertWritingTask(writingTask);
            return Ok("Insert Successfull!!!");
        }

        public class WriterResponesw
        {
            public string Content { get; set; }
            public string Description { get; set; }
            public int Id { get; set; }
            public string Image { get; set; }
            public bool IsChecked { get; set; }
            public string Title { get; set; }

        }

        [HttpPut]
        public IActionResult UpdateWritingTask(WriterResponesw writingTask)
        {
            var wT = writerRepository.GetWritingTaskById(writingTask.Id);
            if (wT == null)
            {
                return NotFound();
            }
            if (writingTask.Title != null)
            {
                wT.Title = writingTask.Title;
            }

            if (writingTask.Description != null)
            {
                wT.Description = writingTask.Description;
            }

            if (writingTask.Content != null)
            {
                wT.Content = writingTask.Content;
            }

            if (wT.IsChecked != true)
            {

                wT.IsChecked = false;


            }
            writerRepository.UpdateWritingTask(wT);
            return Ok("Update Successfull!!!");
        }

        public class FeedBackClass
        {
            public int Id { get; set; }
            public string Comment { get; set; }
        }

        [HttpPut]
        public IActionResult FeedBackTask(FeedBackClass feedBackClass)
        {
            var task = db.WritingTasks.FirstOrDefault(x => x.Id == feedBackClass.Id);
            if (task== null)
            {
                return NotFound();
            }
            task.Comment = feedBackClass.Comment;
            db.Entry<WritingTask>(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Ok("FeedBack Successful!!!");
        }

        [HttpPut]   
        public IActionResult AcceptToPublic(int Id)
        {
            var tas = db.WritingTasks.FirstOrDefault(x =>x.Id == Id);
            if (tas == null)
            {
                return NotFound();
            }
            tas.IsChecked = true;
            db.Entry<WritingTask>(tas).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            foreach (var item in db.Genres.ToList())
            {
                foreach (var i in db.AssignTasks.ToList())
                {
                    if (item.Id == i.GenreId)
                    {
                        if (item.Id == tas.TaskId)
                        {
                            tas.Task.Genre = item;
                            break;
                        }
                    }
                }
            }

            News news = new News
            {
                Title = tas.Title, 
                Description = tas.Description, 
                Content = tas.Content, 
                Image = tas.Image, 
                CreateBy = tas.CreateBy, 
                CreateDate = tas.CreateDate, 
                GenreId = tas.Task.GenreId, 
                Entered = 0, 
            };
            db.News.Add(news);
            db.SaveChanges();
            return Ok("Accept Successfull");
        }

        [HttpDelete]
        public IActionResult DeleteWritingTask(int WriteId)
        {
            var writingTask = writerRepository.GetWritingTaskById(WriteId);
            if (writingTask == null)
            {
                return NotFound();
            }
            writerRepository.DeleteWritingTask(writingTask);
            return Ok("Delete Successfull!!!");
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
    }
}
