using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository comment;
        private readonly IMapper _mapper;
        private readonly PRN231_SUContext db;

        public CommentController(ICommentRepository trackRepository, IMapper mapper, PRN231_SUContext db)
        {
            comment = trackRepository;
            _mapper = mapper;
            this.db= db;
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

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
                await db.SaveChangesAsync();
                return new JsonResult("Insert Successfull!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> LikeComment(int Id)
        {
            try
            {
                var com = await db.Comments.FirstOrDefaultAsync(x => x.Id == Id);
                if (com == null)
                {
                    return NotFound();
                }

                com.LikeAmount = com.LikeAmount + 1;
                db.Entry<Comment>(com).State= EntityState.Modified;
                await db.SaveChangesAsync();
                return new JsonResult("Like Successfull!!!");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UnLikeComment(int Id)
        {
            try
            {
                var com = await db.Comments.FirstOrDefaultAsync(x => x.Id == Id);
                if (com == null)
                {
                    return NotFound();
                }

                com.LikeAmount = com.LikeAmount - 1;
                db.Entry<Comment>(com).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return new JsonResult("UnLike Successfull!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
