using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;  
using HomeFood.Helpers;

namespace HomeFood.Controllers
{
    [Route("api/[controller]")]  
    [ApiController] 
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;  
  
        public TokenController(IConfiguration config)  
        {  
            _config = config;  
        }  
  
        [HttpGet]  
        public string GetRandomToken(string code)  
        {  
            var jwt = new JwtService(_config);  
            var token = jwt.GenerateSecurityToken(code);  
            return token;  
        } 
    }
}