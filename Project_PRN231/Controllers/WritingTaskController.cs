﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                wT.Comment= writingTask.Comment;
                wT.IsChecked = writingTask.IsChecked;
                writerRepository.UpdateWritingTask(wT);
                return Ok("Update Successfull!!!");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
