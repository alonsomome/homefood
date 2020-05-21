using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeFood.Models;
using HomeFood.Entities.Menu;
using HomeFood.Business;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace HomeFood.Controllers{

    [Route("[controller]")]
    [ApiController]
    public class MenuController: ControllerBase
    {
        private readonly BDHomeFoodContext _context;
        private IConfiguration _config;  
        public MenuController(BDHomeFoodContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        public IActionResult GetMenu(MenuEntity model)
        {
            MenuBusiness menuBusiness = new MenuBusiness();
            var response = menuBusiness.GetAllMenu(_context, model);

            if (response.Error == false)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}