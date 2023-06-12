using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using USOS.DAL;
using USOS.Entities;
using USOS.Models;
using USOS.Services;

namespace USOS.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost("login")]
        public bool Login([FromBody]AdminLogin admin)
        {
            AdminDAL _adminDAL = new AdminDAL();
            var result = _adminDAL.Login(admin);
            if(result)
            {
                return true;
            }
            return false;
        }
        [HttpPost]
        public ActionResult Add([FromBody] AdminAdd admin)
        {
            AdminDAL _adminDAL = new AdminDAL();
            _adminDAL.AddAdmin(admin);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Del([FromBody] string username)
        {
            AdminDAL _adminDAL = new AdminDAL();
            if (!_adminDAL.DeleteAdmin(username))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
