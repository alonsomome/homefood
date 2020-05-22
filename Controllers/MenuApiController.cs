using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeFood.Entities.Menu;
using HomeFood.Business.Menu;
using HomeFood.Models;

namespace HomeFood.Controllers
{
    [Route("menuapi")]
    [ApiController]
    public class MenuApiController : Controller
    {
        private readonly BDHomeFoodContext _context;
        public MenuApiController(BDHomeFoodContext context)
        {
            _context = context;
        }

        [HttpGet("menus")]
        public async Task<IActionResult> GetMenu()
        {
            MenuBusiness menuBusiness = new MenuBusiness();
            var response = menuBusiness.GetAllMenu(_context);

            if (response.Error == false)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("menus/{id}")]
        public async Task<IActionResult> GetMenuById(int id){
           MenuBusiness menuBusiness = new MenuBusiness();
            var response = menuBusiness.GetById(_context,id);

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