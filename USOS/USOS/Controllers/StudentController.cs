using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using USOS.Entities;
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
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            var student = _studentService.GetAll();
            return Ok(student);
        }
        [HttpPost]
        public ActionResult AddStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _studentService.Add(student);
            return Ok();
        }
    }
}
