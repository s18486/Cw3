﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s18776;Integrated Security=True";
        private readonly IDBService _dbService;

        public StudentsController(IDBService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent([FromServices] IDBService dbService)
        {
            var list = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Student";
                con.Open();

                SqlDataReader sqlReader = com.ExecuteReader();
                while (sqlReader.Read())
                {
                    var st = new Student();
                    st.BirthDate = DateTime.Parse(sqlReader["BirthDate"].ToString());
                    st.IndexNumber = sqlReader["IndexNumber"].ToString();
                    st.FirstName = sqlReader["FirstName"].ToString();
                    st.LastName = sqlReader["LastName"].ToString();
                    list.Add(st);
                }
            }
            return Ok(list);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult getStudyFor(string indexNumber)
        {

            var list = new List<Enrollment>();
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select Semester,Name,StartDate from Enrollment" +
                                    " inner join Studies on Enrollment.IdStudy = Studies.IdStudy" +
                                    " inner join Student on Student.IdEnrollment = Enrollment.IdEnrollment" +
                                     " where IndexNumber=@studentNumber";
                com.Parameters.AddWithValue("studentNumber", indexNumber);
                con.Open();
                SqlDataReader sqlReader = com.ExecuteReader();
                while (sqlReader.Read())
                {
                    Enrollment enrollment = new Enrollment
                    {
                        Semester = int.Parse(sqlReader["Semester"].ToString()),
                        Study = sqlReader["Name"].ToString(),
                        StartDate = DateTime.Parse(sqlReader["StartDate"].ToString())
                    };
                    list.Add(enrollment);
                }
            }
            if (list.Count() > 0)
                return Ok(list);
            else
                return NotFound("404 No students data was found");
        }
    }
}