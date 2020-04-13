using DomainEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private List<Student> studentList;

        public StudentsController()
        {
            studentList = new List<Student>()
            {
                new Student(){Id=1, FullName="Thanos", Age=999},
                new Student(){Id=2, FullName="Hulk", Age=54},
                new Student(){Id=3, FullName="Spiderman", Age=32},
                new Student(){Id=4, FullName="Ironman", Age=48}
            };
        }
        // GET: api/Students
        public IEnumerable<Student> Get()
        {
            return studentList;
        }

        // GET: api/Students/5
        public Student Get(int id)
        {
            Student student = studentList.SingleOrDefault(s => s.Id == id);
            return student;
        }

        // POST: api/Students
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Students/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
            Student student = studentList.SingleOrDefault(s => s.Id == id);
            studentList.Remove(student);            
        }
    }
}
