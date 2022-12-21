using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Article.Service;
using Article.Model.Entities;
using Article.Model.DTOs;

namespace Article.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class ArticleController : ControllerBase
        {
            private readonly IBaseService<ArticleDto> _article;

            public ArticleController(IBaseService<ArticleDto> service)
            {
                _article = service;
            }
            [HttpGet]
            public IEnumerable<ArticleDto> GetAll()
            {
                return _article.GetAll();
            }
            [HttpGet("{id}")]
            public ArticleDto GetById([FromRoute] int id)
            {
                return _article.GetById(id);
            }
            [HttpPost]
            public IActionResult Add([FromBody] ArticleDto value)
            {
                _article.Add(value);
                return Ok();
            }
            [HttpPut("{id}")]
            public IActionResult Update([FromRoute]int id ,[FromBody] ArticleDto value)
            {
                if (id!= value.Id)
                return BadRequest();
             
                _article.Update(value);
                return NoContent();
            }
            [HttpDelete("{id}")]
            public IActionResult Remove([FromRoute] int id)
            {
                _article.Delete(id);
                return Ok();
            }
        }
}
