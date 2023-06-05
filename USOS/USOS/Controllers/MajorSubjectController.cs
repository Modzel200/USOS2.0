using Microsoft.AspNetCore.Mvc;
using USOS.Entities;
using USOS.Models;
using USOS.Services;

namespace USOS.Controllers
{
    [Route("api/majorsubject")]
    [ApiController]
    public class MajorSubjectController : ControllerBase
    {
        //private readonly IMajorSubjectService _majorSubjectService;

        //public MajorSubjectController(IMajorSubjectService majorSubjectService)
        //{
        //    _majorSubjectService = majorSubjectService;
        //}
        //public ActionResult<IEnumerable<MajorSubject>> GetAllByNames()
        //{
        //    var majorSubjects = _majorSubjectService.GetAll().Select(x => x.Name).ToList();
        //    return Ok(majorSubjects);
        //}
        //[HttpGet]
        //public ActionResult<IEnumerable<MajorSubject>> GetAll()
        //{
        //    var majorSubject = _majorSubjectService.GetAll();
        //    return Ok(majorSubject);
        //}
        //[HttpGet("{id}")]
        //public ActionResult<MajorSubject> GetById([FromRoute] int id)
        //{
        //    var majorSubject = _majorSubjectService.GetById(id);
        //    return Ok(majorSubject);
        //}
        //[HttpPost]
        //public ActionResult Add([FromBody] MajorSubjectAddUpdate majorSubject)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    _majorSubjectService.Add(majorSubject);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public ActionResult Del([FromRoute] int id)
        //{
        //    _majorSubjectService.Del(id);
        //    return Ok();
        //}
        //[HttpPut("{id}")]
        //public ActionResult Update([FromRoute] int id, [FromBody] MajorSubjectAddUpdate majorSubject)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return ValidationProblem(ModelState);
        //    }
        //    var result = _majorSubjectService.Update(id, majorSubject);
        //    if (result) return NoContent();
        //    return NotFound();
        //}
    }
}
