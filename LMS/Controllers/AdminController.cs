using LMS.Authentication;
using LMS.Handler;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMS.Controllers
{
    [Route("/api/v1.0/lms/company/")]
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

        [Route("register")]
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

        [Route("addcourse")]
        [HttpPost]
        public ActionResult addcourse(Registor registor)
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
    }
}
