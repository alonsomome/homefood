using System.Threading.Tasks;
using HomeFood.Business.Customer;
using HomeFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeFood.Controllers
{
    [Route("[controller]")]
    [ApiController]    
    public class CustomerApiController : Controller
    {
        private readonly BDHomeFoodContext _context;
        public CustomerApiController (BDHomeFoodContext context){
            _context = context;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> getPastOrdersByCostumerId(int id){
            CustomerBusiness customerBusiness = new CustomerBusiness();
            var response = customerBusiness.getOrderByCustomerId(_context,id);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
        }      
        
    }
}