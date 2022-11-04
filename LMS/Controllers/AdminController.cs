using LMS.Authentication;
using LMS.Handler;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMS.Controllers
{
    [Authorize]
    [Route("/api/v1.0/lms/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminHandler _adminHandler;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public AdminController(IAdminHandler adminHandler, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this._adminHandler = adminHandler;
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult GetAuthentication(LoginModel loginModel)
        {
            var token = _jwtAuthenticationManager.Authenticate(loginModel.Email, loginModel.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                loginModel.Token = token;
                return Ok(loginModel);
            }
        }

        [AllowAnonymous]
        [Route("company/register")]
        [HttpPost]
        public ActionResult Registor(Registor registor)
        {
            try
            {
                return Ok(_adminHandler.Registor(registor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [AllowAnonymous]
        [Route("company/login")]
        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                return Ok(_adminHandler.GetUser(login));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("courses/addcourse")]
        [HttpPost]
        public ActionResult AddCourse(AddCourse addCourse)
        {
            try
            {
                return Ok(_adminHandler.AddCourse(addCourse));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("courses/delete")]
        [HttpDelete]
        public ActionResult CourseDelete(string courseId)
        {
            try
            {
                return Ok(_adminHandler.DeleteCourse(courseId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("courses/activate")]
        [HttpGet]
        public ActionResult CourseActivate(string courseId)
        {
            try
            {
                return Ok(_adminHandler.Activate(courseId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("courses/getCourse")]
        [HttpGet]
        public ActionResult GetCourse(string isActive)
        {
            try
            {
                return Ok(_adminHandler.GetAllCourse(isActive));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
