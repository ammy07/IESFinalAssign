using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JWTAuthentication_TokenBearer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public List<Users.Result> Get()
        {

            Users.Root root =  JsonConvert.DeserializeObject<Users.Root>(Constants.json);
            List<Users.Result> result = root.result;
            return result; 

        }

        [HttpGet("{id}")]
        public  List<Users.Result> GetUserById(string id)
        {
            
            Users.Root root = JsonConvert.DeserializeObject<Users.Root>(Constants.json);
            List<Users.Result> result = root.result;

            foreach (var users in result)
            {
                if(users.id == id)
                {
                    List<Users.Result> newList = new List<Users.Result>();
                    newList.Add(users);
                   return newList;
                }
            }       
            return null;
        }
    }
}
