using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using USOS.Entities;
using USOS.Models;
using USOS.Services;

namespace USOS.Controllers
{
    [Route("api/lecturer")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;

        public LecturerController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }
        [HttpGet("gethissubjects/{id}")]
        public ActionResult<IEnumerable<string>> GetHisSubjects([FromRoute]int id)
        {
            var result = _lecturerService.GetHisSubjects(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Lecturer>> GetAll()
        {
            var lecturer = _lecturerService.GetAll();
            if(lecturer is null)
            {
                return NotFound();
            }
            return Ok(lecturer);
        }
        [HttpGet("{id}")]
        public ActionResult<Lecturer> GetById([FromRoute] int id)
        {
            var lecturer = _lecturerService.GetById(id);
            if (lecturer is null)
            {
                return NotFound();
            }
            return Ok(lecturer);
        }
        [HttpPost]
        public ActionResult Add([FromBody] LecturerAddUpdate lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _lecturerService.Add(lecturer);
            return Ok();
        }
        [HttpPost("managesubjects/{id}")]
        public ActionResult ManageSubjects([FromRoute] int id, [FromBody] ICollection<string> Subjects)
        {
            if (!_lecturerService.ManageSubjects(id, Subjects))
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Del([FromRoute] int id)
        {
            _lecturerService.Del(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] LecturerAddUpdate lecturer)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var result = _lecturerService.Update(id, lecturer);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
