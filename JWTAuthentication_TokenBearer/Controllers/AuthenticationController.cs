using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JWTAuthentication_TokenBarer.Services;
using JWTAuthentication_TokenBearer.Models;

namespace JWTAuthentication_TokenBearer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {

            _authenticateService = (IAuthenticateService)authenticateService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Student model)
        {
            var student = _authenticateService.Authenticate(model.UserName, model.Password);
            if (student == null)
            {
                return BadRequest(new { Message = "invalid username or password" });
            }
            else
                return Ok(student);
        }
    }
}
