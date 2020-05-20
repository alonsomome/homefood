using System;
using System.Linq;
using HomeFood.Entities.Login;
using HomeFood.Models;
using HomeFood.Controllers;
using HomeFood.Response;
using Microsoft.Extensions.Configuration;
using HomeFood.Helpers;
using System.Transactions;

namespace HomeFood.Business.Login
{
    public class LoginBusiness
    {
       public ResultResponse<string>  RegisterCustomer(BDHomeFoodContext _context, CustomerEntity model){
            try{
                ResultResponse<string> response = new ResultResponse<string>();
               if(model == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Complete los datos";
               }else{

                   if(_context.Customer.Any(x => x.Email == model.Email)){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "El correo electronico ya existe";
                        return response;
                    }
                    if(_context.Customer.Any(x => x.Phone == model.Phone)){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "El número de celular ya existe";
                        return response;
                    }
                    if(_context.Customer.Any(x => x.Username == model.Username)){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "El nombre de usuario ya existe";
                        return response;
                    }
                    using(var ts = new TransactionScope()){
                        Customer customer = new Customer();
                        _context.Customer.Add(customer);
                        customer.Names = model.Names;
                        customer.LastNames = model.LastNames;
                        customer.DocumentoIdentity = model.DocumentIdentity;
                        customer.Email = model.Email;
                        customer.Phone = model.Phone;
                        customer.Birthdate = model.BirthDate;
                        customer.Username = model.Username;
                        customer.Pasword = model.Password;
                        customer.State = ConstantHelpers.Estado.Activo;
                        _context.SaveChanges();
                        ts.Complete();
                        response.Data = null;
                        response.Error = false;
                        response.Message = "Registro satisfactorio";
                    }
                }
               return response;
           }catch(Exception ex){
               throw new Exception(ex.Message);
           }
       }

       public ResultResponse<string> RegisterCollaborator(BDHomeFoodContext _context, CollaboratorEntity model){
           try{
                ResultResponse<string> response = new ResultResponse<string>();
                if(model == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Complete los datos";
                }
                else
                {
                    if(_context.Collaborator.Any(x => x.Email == model.Email)){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "El correo electronico ya existe";
                        return response;
                    }
                    if(_context.Collaborator.Any(x => x.Phone == model.Phone)){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "El número de celular ya existe";
                        return response;
                    }
                    if(_context.Collaborator.Any(x => x.Username == model.Username)){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "El nombre de usuario ya existe";
                        return response;
                    }

                    using(var ts = new TransactionScope()){
                        Collaborator collaborator = new Collaborator();
                        _context.Collaborator.Add(collaborator);
                        collaborator.Names = model.Names;
                        collaborator.LastNames = model.LastNames;
                        collaborator.DocumentIdentity = model.DocumentIdentity;
                        collaborator.Email = model.Email;
                        collaborator.Phone = model.Phone;
                        collaborator.BirthDate = model.BirthDate;
                        collaborator.Username = model.Username;
                        collaborator.Password = model.Password;
                        collaborator.CollaboratorTypeId = model.CollaboratorTypeId;
                        collaborator.State = ConstantHelpers.Estado.Activo;
                        collaborator.StateActivity = ConstantHelpers.Estado.Activo;
                        _context.SaveChanges();
                        ts.Complete();
                        response.Data = null;
                        response.Error = false;
                        response.Message = "Registro satisfactorio";
                    }
                
                } 
                return response;
           }catch(Exception ex){
               throw new Exception(ex.Message);
           }
       } 
       
       public ResultResponse<LoginCollaboratorResponse> LogInCollaborator(BDHomeFoodContext _context, IConfiguration _config, LoginEntity model){
           try{
               ResultResponse<LoginCollaboratorResponse> response = new ResultResponse<LoginCollaboratorResponse>();

                var userCollaborator = _context.Collaborator.Any(x=>x.Username == model.Username && x.Password == model.Password);
                if(userCollaborator){
                    var collaborator = _context.Collaborator.FirstOrDefault(x=>x.Username == model.Username && x.Password == model.Password);
                    
                    var jwt = new JwtService(_config);  
                    var token = jwt.GenerateSecurityToken(collaborator.Email); 
                    
                    LoginCollaboratorResponse loginResponse = new LoginCollaboratorResponse{
                        Token = token,
                        CollaboratorId = collaborator.CollaboratorId,
                        Names = collaborator.Names,
                        LastNames = collaborator.LastNames
                    };

                    response.Data = loginResponse;
                    response.Error = false;
                    response.Message = "Inicio de sesión satisfactorio";

                }
                else
                {
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Usuario y/o password incorrecto";
                }
                return response;
           }catch(Exception ex){
               throw new Exception(ex.Message);
           }
       }

       public ResultResponse<LoginCustomerResponse> LogInCustomer(BDHomeFoodContext _context, IConfiguration _config, LoginEntity model){
           try{
               ResultResponse<LoginCustomerResponse> response = new ResultResponse<LoginCustomerResponse>();

                var userCustomer = _context.Customer.Any(x=>x.Username == model.Username && x.Pasword == model.Password);
                if(userCustomer){
                    var customer = _context.Customer.FirstOrDefault(x=>x.Username == model.Username && x.Pasword == model.Password);
                    
                    var jwt = new JwtService(_config);  
                    var token = jwt.GenerateSecurityToken(customer.Email); 
                    
                    LoginCustomerResponse loginResponse = new LoginCustomerResponse{
                        Token = token,
                        CustomerId = customer.CustomerId,
                        Names = customer.Names,
                        LastNames = customer.LastNames
                    };

                    response.Data = loginResponse;
                    response.Error = false;
                    response.Message = "Inicio de sesión satisfactorio";

                }
                else
                {
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Usuario y/o password incorrecto";
                }
                return response;
           }catch(Exception ex){
               throw new Exception(ex.Message);
           }
       }
    }
}