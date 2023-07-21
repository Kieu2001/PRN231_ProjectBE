using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository comment;
        private readonly IMapper _mapper;

        public CommentController(ICommentRepository trackRepository, IMapper mapper)
        {
            comment = trackRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCommentBrowseList()
        {
            var lstUser = comment.GetCommentBrowseList();
            return Ok(lstUser);
        }

        [HttpGet]
        public IActionResult GetCommentById(int id)
        {
            return Ok(comment.GetCommentById(id));
        }


        [HttpPut]
        public IActionResult UpdateCommentTrue(int Id)
        {
            var g = comment.GetCommentById(Id);
            if (g == null)
            {
                return NotFound();
            }
            comment.UpdateCommentTrue(Id);
            return Ok("Update Successfull!!!");
        }

        [HttpPut]
        public IActionResult UpdateCommentFalse(int Id)
        {
            var g = comment.GetCommentById(Id);
            if (g == null)
            {
                return NotFound();
            }
            comment.UpdateCommentFalse(Id);
            return Ok("Update Successfull!!!");
        }


        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var g = comment.GetCommentById(id);
            if (g == null)
            {
                return NotFound();
            }
            comment.DeleteComment(id);
            return Ok();
        }

    }
}
