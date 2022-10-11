using LMD.Data.Handler;
using LMD.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMD.Data.Controllers
{
    [Route("/api/v1.0/lms/courses/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _userHandler;
       
        public UserController(IUserHandler userHandler)
        {
            this._userHandler = userHandler;            
        }

        [Route("info/get")]
        [HttpPost]
        public ActionResult TechnologyInfo(Course course)
        {
            try
            {
                return Ok(_userHandler.GetAllCourse(course));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
