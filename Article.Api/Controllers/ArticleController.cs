using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Article.Service;
using Article.Model.Entities;

namespace Article.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class ArticleController : ControllerBase
        {
            private readonly IBaseService<Articles> _article;

            public ArticleController(IBaseService<Articles> service)
            {
                _article = service;
            }
            [HttpGet]
            public IEnumerable<Articles> GetAll()
            {
                return _article.GetAll();
            }
            [HttpGet("{id}")]
            public Articles GetById([FromRoute] int id)
            {
                return _article.GetById(id);
            }
            [HttpPost]
            public IActionResult Add([FromBody] Articles value)
            {
                _article.Add(value);
                return Ok();
            }
            [HttpPut]
            public IActionResult Update([FromBody] Articles value)
            {
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
