using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;
using System.Threading.Tasks.Dataflow;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly PRN231_SUContext db;
        private readonly IGenreRepository gen;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository trackRepository, IMapper mapper, PRN231_SUContext db)
        {
            gen = trackRepository;
            _mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAllGenre() 
        { 
            return Ok(gen.GetAllGenre());
        }

        [HttpPost]
        public IActionResult InsertGenre(Genre genre)
        {
            gen.InsertGenre(genre);
            return Ok("Inserted Successfull!!!");
        }

        [HttpPut] 
        public IActionResult UpdateGenre(Genre genre)
        {
            var g = gen.GetGenreById(genre.Id);
            if (g == null)
            {
                return NotFound();
            }
            gen.UpdateGenre(genre);
            return Ok("Update Successfull!!!");
        }

        [HttpPut]
        public async Task<IActionResult> DeleteGenre(int Id)
        {
            var g = gen.GetGenreById(Id);
            if (g == null)
            {
                return NotFound();
            }
            try
            {
                g.IsDeleted = true;
                db.Entry<Genre>(g).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
                return new JsonResult("Delete Successfull!!!");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
