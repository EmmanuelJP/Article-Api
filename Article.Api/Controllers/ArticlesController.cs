<<<<<<< Updated upstream
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Article.Service;
using Article.Service.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Serilog;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
        [HttpGet]
        public IEnumerable<ArticleDto> GetAll()
        {
            try
            {
               throw new System.Exception("Add-database");
               // return _articleServices.GetAll();
            }
            catch (System.Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw ex;
            }
            
        }
        [HttpGet("{id}")]
        public ArticleDto GetById([FromRoute] int id)
        {
            return _articleServices.GetById(id);
        }
        [HttpPost]
        public IActionResult Add([FromBody] ArticleDto value)
        {
            _articleServices.Add(value);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ArticleDto value)
        {
            if (id != value.Id)
                return BadRequest();

            _articleServices.Update(value);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _articleServices.Delete(id);
            return Ok();
        }
    }
>>>>>>> Stashed changes
}
