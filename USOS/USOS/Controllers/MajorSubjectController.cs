﻿using Microsoft.AspNetCore.Mvc;
using USOS.Entities;
using USOS.Models;
using USOS.Services;

namespace USOS.Controllers
{
    [Route("api/majorsubject")]
    [ApiController]
    public class MajorSubjectController : ControllerBase
    {
        private readonly IMajorSubjectService _majorSubjectService;

        public MajorSubjectController(IMajorSubjectService majorSubjectService)
        {
            _majorSubjectService = majorSubjectService;
        }
        [HttpGet("getitssubjects/{id}")]
        public ActionResult<IEnumerable<string>> GetItsSubjects([FromRoute] int id)
        {
            var result = _majorSubjectService.GetItsSubjects(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        public ActionResult<IEnumerable<MajorSubject>> GetAll()
        {
            var majorSubject = _majorSubjectService.GetAll();
            return Ok(majorSubject);
        }
        [HttpGet("getallmajorsubjects")]
        public ActionResult<IEnumerable<string>> GetAllMajorSubjects()
        {
            var majorSubject = _majorSubjectService.GetAllMajorSubjects();
            if (majorSubject is null) return NotFound();
            return Ok(majorSubject);
        }
        [HttpGet("{id}")]
        public ActionResult<MajorSubject> GetById([FromRoute] int id)
        {
            var majorSubject = _majorSubjectService.GetById(id);
            return Ok(majorSubject);
        }
        [HttpPost("managesubjects/{id}")]
        public ActionResult ManageSubjects([FromRoute] int id, [FromBody] ICollection<string> Subjects)
        {
            if (!_majorSubjectService.ManageSubjects(id, Subjects))
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult Add([FromBody] MajorSubjectAddUpdate majorSubject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _majorSubjectService.Add(majorSubject);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Del([FromRoute] int id)
        {
            _majorSubjectService.Del(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] MajorSubjectAddUpdate majorSubject)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var result = _majorSubjectService.Update(id, majorSubject);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
