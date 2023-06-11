﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult getNewsByDate()
        {
            var listNewsByDate = newsRepository.GetNewsByDate();
            if(listNewsByDate == null)
            {
                return NotFound();
            }
            return Ok(listNewsByDate);
        }

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

    }
}
