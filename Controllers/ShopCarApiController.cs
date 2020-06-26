using System.Threading.Tasks;
using HomeFood.Business.ShopCar;
using HomeFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeFood.Controllers
{
    [Route("[controller]")]
    [ApiController]  
    public class ShopCarApiController : Controller
    {
        private readonly BDHomeFoodContext _context;
        public ShopCarApiController (BDHomeFoodContext context){
            _context = context;
        }        
        
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> getPastOrdersByCostumerId(int id){
            ShopCarBusiness shopCarBusiness = new ShopCarBusiness();
            var response = shopCarBusiness.GetByCustomerId(_context,id);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
        }  
    }
}