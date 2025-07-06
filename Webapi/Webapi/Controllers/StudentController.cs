using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("All")]
        public IEnumerable<Student> GetStudentName()
        {
            return CollegeRepository.Students;
        }
        [HttpGet("{id}")]
        public Student GetStudentNameById(int id)
        {
            var student = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
            if(student == null)
            {
                throw new Exception("No student for this id");
            }
            return student;
        }
        [HttpGet("{name}")]
        public Student GetStudentNameByName(string name)
        {
            var student = CollegeRepository.Students.Where(x => x.StudentName == name).FirstOrDefault();
            if (student == null)
            {
                throw new Exception("No student for this name");
            }
            return student;
        }
        [HttpPost]
        public Student AddStudent(Student s)
        {
            var student = new Student()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Email = s.Email,
                Address = s.Address
            };
            CollegeRepository.Students.Add(student);
            return student;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void),(int) HttpStatusCode.OK)]
        public void DeleteStudent(int id)
        {
            var student = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null)
            {
                throw new Exception("No student for this id");
            }
            CollegeRepository.Students.Remove(student);
        }
        [HttpPut("{id}")]
        public ActionResult<Student> UpdateStudent(int id, Student updatedStudent)
        {
            var student = CollegeRepository.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound($"No student found with ID {id}.");
          
            student.StudentName = updatedStudent.StudentName;
            student.Email = updatedStudent.Email;
            student.Address = updatedStudent.Address;

            return Ok(student); 
        }
    }
}


