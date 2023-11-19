using Microsoft.AspNetCore.Mvc;
using SchoolSis.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolSis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        static int id = 1;
        private static List<Course> courses = new List<Course> { new Course { Id = id++, Name="History",Description="A heavy and boring theoretical course"}
         };
        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return courses;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            Course c = courses.Find(item => item.Id == id);
            if (c == null)
                return NotFound();
            return Ok(c);
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] Course course)
        {
            courses.Add(new Course { Id = id++, Name = course.Name, Description = course.Description });

        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course course)
        {

            Course c = courses.Find(item => item.Id == id);
            if (c == null)
                return NotFound();
            courses.Remove(c);
            c.Name = course.Name;
            c.Description = course.Description;
            courses.Add(c);
            return Ok();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Course c = courses.Find(item => item.Id == id);
            if(c == null)
                return NotFound();
            courses.Remove(c);
            return Ok();
        }
    }
}
