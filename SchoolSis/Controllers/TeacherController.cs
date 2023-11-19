using Microsoft.AspNetCore.Mvc;
using SchoolSis.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolSis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        static int id = 1;
        private static List<Teacher> teachers = new List<Teacher> { new Teacher { Id = id++, Name="Tachan",Subject="History",Status=0}
         };
        // GET: api/<TheacherController>
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return teachers;
        }

        // GET api/<TheacherController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            Teacher t = teachers.Find(item => item.Id == id);
            if (t == null)
                return NotFound();
            return Ok(t);
            

        }

        // POST api/<TheacherController>
        [HttpPost]
        public void Post([FromBody] Teacher t)
        {
            teachers.Add(new Teacher { Id = id++, Name = t.Name, Subject = t.Subject, Status = t.Status });

        }

        // PUT api/<TheacherController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Teacher t)
        {
            Teacher te = teachers.Find(item => item.Id == id);
            if (t == null)
                return NotFound();
            teachers.Remove(te);
            te.Name = t.Name;
            te.Subject = t.Subject;
            te.Status = t.Status;
            return Ok();
        }
        [HttpPut("{id}/{status}")]
        public ActionResult Put(int id,int status, [FromBody] Teacher t)
        {
            Teacher te = teachers.Find(item => item.Id == id);
            if (t == null)
                return NotFound();
            teachers.Remove(te);
            te.Name = t.Name;
            te.Subject = t.Subject;
            te.Status = status;
            return Ok();
        }


        // DELETE api/<TheacherController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Teacher te = teachers.Find(item => item.Id == id);
            if (te == null)
                return NotFound();
            teachers.Remove(te);
            return Ok();
        }
    }
}
