using Microsoft.AspNetCore.Mvc;
using USOS.Entities;
using USOS.Services;

namespace USOS.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController:ControllerBase
    {
        private StudentService _studentService;

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
    }
}
