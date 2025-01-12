﻿using AbsenseApi.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentLibrary;

namespace AbsenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AbsenseApiController : ControllerBase
    {
        
        private readonly AbsenseApiManager _manager = new AbsenseApiManager();

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet]
        //public IEnumerable<Student> Get()
        //{
        //    return _manager.GetAll();
        //}

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IEnumerable<Student> Get([FromQuery] string ?name)
        {
            return _manager.GetAll(name);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{nFCId}")]
        public ActionResult<Student> Get(int nFCId)
        {
            Student student = _manager.GetByNFCId(nFCId);
            if (student == null) return NotFound("lmao");
            return student;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student value)
        {
            Student students = _manager.Add(value);
            return Created("/" + students.StudentId ,students);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{nFCId}")]
        public ActionResult<Student> Put(int nFCId, [FromBody] Student value)
        {
            Student student = _manager.Update(nFCId, value);
            if (student == null) return NotFound("There is no student with the given Id");
            return Ok(value);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Student> Delete(int id)
        {
            Student student = _manager.Delete(id);
            if (student == null) return NotFound("There is no student with that id");
            return Ok(student);
            

        }




    }
}
