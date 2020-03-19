using System;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDBService service;

        public StudentsController(IDBService db)
        {
            service = db;
        }

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
        public IActionResult GetStudents3()
        {
            return Ok(service.GetStudents());
        }

        [HttpPost]
        public IActionResult CreateSudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent(int id)
        {

            return Ok($"Aktualizacja {id} dokonczona");
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveStudent(int id)
        {

            return Ok($"Usuwanie {id} zakonczone");
        }
    }
}