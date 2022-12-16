using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Article.Service;
using Article.Model.Entities;

namespace Article.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class ArticlesController : ControllerBase
        {
            private readonly IBaseService<Model.Entities.Article> _articleService;

            public ArticlesController(IBaseService<Model.Entities.Article> service)
            {
                _articleService = service;
            }
            [HttpGet]
            public IEnumerable<Model.Entities.Article> GetAll()
            {
                return _articleService.GetAll();
            }
            [HttpGet("{id}")]
            public Model.Entities.Article GetById([FromRoute] int id)
            {
                return _articleService.GetById(id);
            }
            [HttpPost]
            public IActionResult Add([FromBody] Model.Entities.Article value)
            {
                _articleService.Add(value);
                return Ok();
            }
            [HttpPut("{id}")]
            public IActionResult Update([FromRoute]int id ,[FromBody] Model.Entities.Article value)
            {
                _articleService.Update(value);
                return NoContent();
            }
            [HttpDelete("{id}")]
            public IActionResult Remove([FromRoute] int id)
            {
                _articleService.Delete(id);
                return Ok();
            }
        }
}
