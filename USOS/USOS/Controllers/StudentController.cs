using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using USOS.Entities;
using USOS.Models;
using USOS.Services;

namespace USOS.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController:ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("gethismajorsubject/{id}")]
        public ActionResult<IEnumerable<string>> GetHisMajorSubject([FromRoute]int id)
        {
            var students = _studentService.GetHisMajorSubject(id);
            return Ok(students);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            var student = _studentService.GetAll();
            return Ok(student);
        }
        [HttpGet("{index}")]
        public ActionResult<Student> GetByIndex([FromRoute] int index)
        {
            var student = _studentService.GetByIndex(index);
            return Ok(student);
        }
        [HttpPost]
        public ActionResult Add([FromBody] StudentAdd student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _studentService.Add(student);
            return Ok();
        }
        [HttpDelete("{index}")]
        public ActionResult Del([FromRoute] int index)
        {
            _studentService.Del(index);
            return Ok();
        }
        [HttpPut("{index}")]
        public ActionResult Update([FromRoute] int index, [FromBody] StudentUpdate student)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var result = _studentService.Update(index, student);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
