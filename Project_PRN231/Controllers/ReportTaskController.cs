using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportTaskController : ControllerBase
    {
        public PRN231_SUContext db = new PRN231_SUContext();
        private readonly IWebHostEnvironment _env;
        private IReporterRepository reporterRepository;
        public ReportTaskController(IReporterRepository _reporterRepository, IWebHostEnvironment webHostEnvironment)
        {
            reporterRepository = _reporterRepository;
            _env = webHostEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(List<IFormFile> files, int TaskId)
        {
            if (files.Count== 0)
            {
                return BadRequest();
            }
            long size = files.Sum(f => f.Length);
            var rootPath = Path.Combine(_env.ContentRootPath, "Upload", "Files");
            if (Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            foreach (var item in files)
            {
                var filePath = Path.Combine(rootPath, item.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    var document = new Document
                    {
                        FileName = item.FileName,
                        ContentType = item.ContentType,
                        FileSize = item.Length,
                        TaskId = TaskId
                    };
                    await item.CopyToAsync(stream);
                    db.Documents.Add(document);
                    await db.SaveChangesAsync();
                }
            }
            return Ok("Insert SuccessFull!!!");
        }

        [HttpPost]
        public async Task<ActionResult> DownLoadFile(int id)
        {
            var provider = new FileExtensionContentTypeProvider();
            var document = await db.Documents.FirstOrDefaultAsync(x => x.Id == id);
            if (document == null)
            {
                return NotFound();
            }
            var file = Path.Combine(_env.ContentRootPath, "Upload", "Files", document.FileName);
            string contentType;
            if (!provider.TryGetContentType(file, out contentType))
            {
                contentType = "application/octet-stream";
            }
            byte[] fileBytes;
            if (System.IO.File.Exists(file))
            {
                fileBytes = System.IO.File.ReadAllBytes(file);
            }
            else
            {
                return NotFound();
            }
            return File(fileBytes, contentType, document.FileName);
        }

        [HttpGet]
        public IActionResult getDocumentById(int Id)
        {
            var lstDoc = db.Documents.Where(x => x.TaskId == Id).ToList();
            if (lstDoc.Count == 0)
            {
                return NotFound();
            }
            return Ok(lstDoc);
        }

        [HttpGet]
        public IActionResult GetAllReportTask()
        {
            var listReportTask = reporterRepository.GetAllTask();
            if (listReportTask == null)
            {
                return NotFound();
            }
            foreach (var item in listReportTask)
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
            return Ok(listReportTask);
        }

        [HttpGet]
        public IActionResult GetReportTaskById(int Id)
        {
            var ReportTask = reporterRepository.GetTaskById(Id);
            if (ReportTask == null)
            {
                return NotFound();
            }
            return Ok(ReportTask);
        }

        [HttpPost]
        public IActionResult InsertReportTask(ReportTask reportTask)
        {
            reporterRepository.InsertReportTask(reportTask);
            return Ok("Insert Successfull!!!");
        }

        [HttpPut]
        public IActionResult UpdateReportTask(ReportTask reportTask)
        {
            var rT = reporterRepository.GetTaskById(reportTask.Id);
            if (rT == null)
            {
                return NotFound();  
            }
            reporterRepository.UpdateReportTask(rT);    
            return Ok("Update Successfull!!!");
        }

        [HttpDelete]
        public IActionResult DeleteReportTask(int Id)
        {
            var rT = reporterRepository.GetTaskById(Id);
            if (rT == null)
            {
                return NotFound();
            }
            reporterRepository.DeleteReportTask(rT);
            return Ok("Delete Successfull!!!");
        }


        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        //{
        //    await WriteFile(file);
        //    return Ok();
        //}

        //private async Task<bool> WriteFile(IFormFile file)
        //{
        //    bool isSaveSuccess = false;
        //    string fileName;
        //    try
        //    {
        //        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        //        fileName = DateTime.Now.Ticks + extension;
        //        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

        //        if (!Directory.Exists(pathBuilt))
        //        {
        //            Directory.CreateDirectory(pathBuilt);
        //        }

        //        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }
        //        isSaveSuccess = true;

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return isSaveSuccess;
        //}
    }
}
