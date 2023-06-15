using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Models;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly PRN231_SUContext db;
        public DocumentController(PRN231_SUContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetAllDocumentByTaskId(int TaskId)
        {
            var listDoc = db.Documents.Where(x => x.TaskId == TaskId).ToList();
            if (listDoc == null)
            {
                return NotFound();
            }
            return Ok(listDoc);
        }

        [HttpDelete]
        public IActionResult DeleteDocument(int id)
        {
            var doc = db.Documents.FirstOrDefault(x => x.Id == id);
            if (doc == null)
            {
                return NotFound();
            }
            db.Documents.Remove(doc);
            db.SaveChanges();
            return Ok("Delete Successfull!!!");
        }
    }
}
