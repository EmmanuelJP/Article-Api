<<<<<<< HEAD
<<<<<<< Updated upstream
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Article.Service;
using Article.Service.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Serilog;
>>>>>>> Stashed changes
=======
﻿using Article.Service;
using Article.Service.DTOs;
using Microsoft.AspNetCore.Mvc;
>>>>>>> main
using System.Collections.Generic;

namespace Article.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IBaseService<ArticleDto> _articleServices;

        public ArticlesController(IBaseService<ArticleDto> service)
        {
            _articleServices = service;
        }
<<<<<<< HEAD
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
            
=======
        [HttpGet]
        public IEnumerable<ArticleDto> GetAll()
        {
            return _articleServices.GetAll();
>>>>>>> main
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
<<<<<<< HEAD
>>>>>>> Stashed changes
=======
>>>>>>> main
}
