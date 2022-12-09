using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Article.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class ArticleController : ControllerBase
        {
            private readonly IService<Student> students;

            public StudentsController(IService<Student> service)
            {
                students = service;
            }
            [HttpGet]
            public IEnumerable<Student> GetAll()
            {
                return students.GetAll();
            }
            [HttpGet("{id}")]
            public Student GetById([FromRoute] Guid id)
            {
                return students.GetById(id);
            }
            [HttpPost]
            public IActionResult Add([FromBody] Student value)
            {
                students.Add(value);
                return Ok();
            }
            [HttpPut]
            public IActionResult Update([FromBody] Student value)
            {
                students.Update(value);
                return NoContent();
            }
            [HttpDelete("{id}")]
            public IActionResult Remove([FromRoute] Guid id)
            {
                students.Remove(id);
                return Ok();
            }
        }
}
