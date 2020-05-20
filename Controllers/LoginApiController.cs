using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeFood.Models;
using HomeFood.Business.Login;
using HomeFood.Entities.Login;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace HomeFood.Controllers
{
    [Route("loginapi")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly BDHomeFoodContext _context;
        private IConfiguration _config;  

        public LoginApiController(BDHomeFoodContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("collaboratorlogin")]
        public async Task<IActionResult> PostLogInCollaborator(LoginEntity model)
        {
            LoginBusiness loginBusiness = new LoginBusiness();
            var response = loginBusiness.LogInCollaborator(_context, _config, model);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
        }
        [HttpPost("customerlogin")]
        public async Task<IActionResult> PostLogInCustomer(LoginEntity model)
        {
            LoginBusiness loginBusiness = new LoginBusiness();
            var response = loginBusiness.LogInCustomer(_context, _config,  model);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
        }
        [HttpPost("collaborator")]
        public async Task<IActionResult> PostRegisterCollaborator(CollaboratorEntity model)
        {
            LoginBusiness loginBusiness = new LoginBusiness();
            var response = loginBusiness.RegisterCollaborator(_context, model);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
         
        }
        [HttpPost("customer")]
        public async Task<IActionResult> PostRegisterCustomer(CustomerEntity model)
        {
            LoginBusiness loginBusiness = new LoginBusiness();
            var response = loginBusiness.RegisterCustomer(_context, model);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
        }

        
        // PUT: api/LoginApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

    }
}
