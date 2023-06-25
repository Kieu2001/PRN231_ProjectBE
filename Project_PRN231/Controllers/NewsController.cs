using Microsoft.AspNetCore.Mvc;
using Project_PRN231.Models;
using Project_PRN231.Repositories;
using Project_PRN231.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_PRN231.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository newsRepository;
        public NewsController(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult getAllNews()
        {
            var listNews = newsRepository.GetNewsList();
            if(listNews == null)
            {
                return NotFound();
            }
            return Ok(listNews);
        }

        //[HttpGet]
        //public IActionResult getNewsByDate()
        //{
        //    var listNewsByDate = newsRepository.GetNewsByDate();
        //    if(listNewsByDate == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(listNewsByDate);
        //}

        [HttpGet]
        public IActionResult getNewsById(int id)
        {
            var news = newsRepository.getNewsById(id);
            if(news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        [HttpPost]
        public IActionResult InsertNews(News news)
        {
            newsRepository.AddNews(news);
            return Ok("Insert Successfull!!!");
        }

        [HttpPut]
        public IActionResult UpdateNews(News news)
        {
            var newsUpdate = newsRepository.getNewsById(news.Id); 
            if (newsUpdate == null)
            {
                return NotFound();
            }
            newsRepository.Update(newsUpdate);
            return Ok("Update Successfull!!!");
        }

        [HttpDelete]
        public IActionResult DeleteNews(int Id)
        {
            var newsU = newsRepository.getNewsById(Id);
            if (newsU == null)
            {
                return NotFound();
            }
            newsRepository.Delete(newsU);
            return Ok("Delete Successfull!!!");
        }

        [HttpGet]
        public IActionResult getAllGenres()
        {
            var listGenre = newsRepository.GetAllGenres();
            if(listGenre == null)  return NotFound();
            return Ok(listGenre);
        }
        [HttpGet]
        public IActionResult getNewByGenreId(int id)
        {
            var list = newsRepository.GetNewsByGenreId(id);
            if (list == null) return NotFound();
            return Ok(list);
        }
        [HttpGet("data")]
        public IActionResult GetData( int page )
        {
            int pageSize = 2;
            var allData = newsRepository.GetNewsList();
            int startIndex = (page - 1) * pageSize;
            int endIndex = page * pageSize;

            var currentPageData = allData.Skip(startIndex).Take(pageSize);
            return Ok(currentPageData);
        }

        [HttpGet]
        public IActionResult GetDataByDate(int page)
        {
            int pageSize = 2;
            var allData = newsRepository.GetNewsByDate();
            int startIndex = (page - 1) * pageSize;
            int endIndex = page * pageSize;

            var currentPageData = allData.Skip(startIndex).Take(pageSize);
            return Ok(currentPageData);
        }
        [HttpGet]
        public IActionResult getNewsFirst()
        {
            var newfirst = newsRepository.newsFirst();

            return Ok(newfirst);
        }

        //[HttpGet]
        //public IActionResult getNewsByDate(int begin, int end)
        //{
        //    var listNewsByDate = newsRepository.GetNewsByDate(begin, end);
        //    if (listNewsByDate == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(listNewsByDate);
        //}
    }
}
