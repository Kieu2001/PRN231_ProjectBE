using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository gen;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository trackRepository, IMapper mapper)
        {
            gen = trackRepository;
            _mapper = mapper;
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

        [HttpDelete]
        public IActionResult DeleteGenre(int genreId)
        {
            var g = gen.GetGenreById(genreId);
            if (g == null)
            {
                return NotFound();
            }
            gen.DeleteGenre(genreId);
            return Ok("Delete Successfull!!!");
        }
    }
}
