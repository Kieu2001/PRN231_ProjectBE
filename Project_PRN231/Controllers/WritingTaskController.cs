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
        public PRN231_SUContext db = new PRN231_SUContext();
        public WritingTaskController(IWriterRepository _writerRepository)
        {
            writerRepository = _writerRepository;
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

            foreach (var item in db.Users.ToList())
            {
                if (item.Id == wT.UserId)
                {
                    wT.User = item;
                    break;
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
    }
}
