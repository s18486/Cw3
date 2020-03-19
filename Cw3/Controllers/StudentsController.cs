using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        /*[HttpGet]
        public string GetStudents()
        {
            return "ss,gg";
        }*/
        
        [HttpGet("{id:int}")]
        public IActionResult GetStudents2(int id)
        {
            if (id == 1)
                return Ok("Kowalski");
            else
                return Ok("Malewski");
            return NotFound("Nie znalezniono studenta");
        }

        [HttpGet]
        public string GetStudents3(string st)
        {
            return st;
        }
    }
}