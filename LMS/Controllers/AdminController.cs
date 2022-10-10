using LMS.Authentication;
using LMS.Handler;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{

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

        [Route("/api/v1.0/lms/company/register")]
        [HttpPost]
        public ActionResult Registor(Registor registor)
        {
            try
            {
                return Ok(_adminHandler.Handler(registor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
