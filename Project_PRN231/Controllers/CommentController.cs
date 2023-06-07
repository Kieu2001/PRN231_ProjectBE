using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
	}
}
