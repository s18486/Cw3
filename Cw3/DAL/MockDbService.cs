using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.DAL
{
    public class MockDbService : IDBService
    {
        private static IEnumerable<Student> students;

        static MockDbService()
        {
            students = new List<Student> 
            {
                new Student{IndexNumber = "1", FirstName = "John",LastName = "Cena"},
                new Student{IndexNumber = "2", FirstName = "The", LastName = "Rock"},
                new Student{IndexNumber = "3", FirstName = "Randy",LastName = "Orton"}
            };

        }

        public IEnumerable<Student> GetStudents()
        {
            return students;
        }
    }
}
