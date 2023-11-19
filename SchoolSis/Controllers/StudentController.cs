using Microsoft.AspNetCore.Mvc;
using SchoolSis.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolSis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static int id = 1;
        private static List<Student> students = new List<Student> { new Student { Id = id++, Name="Ruth",Age= 15, Status=1},
           new Student { Id = id++, Name="Miri",Age= 19, Status=0},
            new Student { Id = id++, Name="Shulamith",Age= 18, Status=1}
        };
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            Student st = students.Find(item => item.Id == id);
            if (st == null)
                return NotFound();
            return Ok(st);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            students.Add(new Student { Id = id++, Name = student.Name, Age = student.Age, Status = student.Status });
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student newStudent)
        {
            Student st = students.Find(item => item.Id == id);
            if (st == null)
                return NotFound();
            students.Remove(st);
            st.Name = newStudent.Name;
            st.Age = newStudent.Age;
            st.Status = newStudent.Status;
            students.Add(st);
            return Ok();
        }
        [HttpPut("{id}/{status}")]
        public ActionResult Put(int id,int status, [FromBody] Student newStudent)
        {
            Student st = students.Find(item => item.Id == id);
            if (st == null)
                return NotFound();
            students.Remove(st);
            st.Name = newStudent.Name;
            st.Age = newStudent.Age;
            st.Status = status;
            students.Add(st);
            return Ok();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Student st = students.Find(item => item.Id == id);
            if (st == null)
                return NotFound();
            students.Remove(st);
            return Ok(st);
        }
    }
}
