using Microsoft.AspNetCore.Mvc;
using USOS.Entities;
using USOS.Models;
using USOS.Services;

namespace USOS.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet("getnames")]
        public ActionResult<IEnumerable<Subject>> GetAllByNames()
        {
            var subjects = _subjectService.GetAll().Select(x => x.Name).ToList();
            return Ok(subjects);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Subject>> GetAll()
        {
            var subject = _subjectService.GetAll();
            return Ok(subject);
        }
        [HttpGet("{id}")]
        public ActionResult<Subject> GetById([FromRoute] int id)
        {
            var subject = _subjectService.GetById(id);
            return Ok(subject);
        }
        [HttpPost]
        public ActionResult Add([FromBody] SubjectAddUpdate subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _subjectService.Add(subject);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Del([FromRoute] int id)
        {
            _subjectService.Del(id);
            return Ok();
        }
        //[HttpPut("{id}")]
        //public ActionResult Update([FromRoute] int id, [FromBody] SubjectAddUpdate subject)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return ValidationProblem(ModelState);
        //    }
        //    var result = _subjectService.Update(id, subject);
        //    if (result) return NoContent();
        //    return NotFound();
        //}
    }
}
