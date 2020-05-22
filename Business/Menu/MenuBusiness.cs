using System;
using System.Linq;
using HomeFood.Models;
using HomeFood.Entities;
using HomeFood.Controllers;
using HomeFood.Response;
using Microsoft.Extensions.Configuration;
using HomeFood.Entities.Menu;
using HomeFood.Helpers;
using System.Transactions;
using System.Collections.Generic;

namespace HomeFood.Business.Menu
{
    public class MenuBusiness
    {
        public ResultResponse<List<MenuResponse>> GetAllMenu(BDHomeFoodContext _context)
        {
            try
            {
                ResultResponse<List<MenuResponse>> response = new ResultResponse<List<MenuResponse>>();
                // var result = _context.Menu.FirstOrDefault(x=>x.MenuId==model.MenuId);
                var result = _context.Menu.Select( x=> new MenuResponse{
                    MenuId = x.MenuId,
                    Name = x.Name,
                    Description = x.Description,
                    CollaboratorId = x.CollaboratorId,
                    Price = x.Price,
                    State = x.State,
                    QuantityMenuCurrent = x.QuantityMenuCurrent,
                    MenuTypeId = x.MenuTypeId
                } ).ToList();
                
                if(result.Count != 0){
                    response.Data = result;
                    response.Error = false;
                    response.Message ="datos encontrados";
                }else{
                    response.Data = result;
                    response.Error = true;
                    response.Message ="No se encontraron datos";
                }                
                return response;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<MenuResponse> GetById(BDHomeFoodContext _context, int id)
        {
            try
            {
                ResultResponse<MenuResponse> response = new ResultResponse<MenuResponse>();
                var firstresult = _context.Menu.Any(c => c.MenuId == id);

                if(firstresult)
                {
                    var result = _context.Menu.FirstOrDefault(c => c.MenuId == id);

                    MenuResponse menuResponses = new MenuResponse
                    {
                        MenuId = result.MenuId,
                        Name = result.Name,
                        Description = result.Description,
                        CollaboratorId = result.CollaboratorId,
                        Price = result.Price,
                        State = result.State,
                        QuantityMenuCurrent = result.QuantityMenuCurrent,
                        MenuTypeId = result.MenuTypeId
                    };

                    response.Data = menuResponses;
                    response.Error = false;
                    response.Message = "Datos encontrados";

                }else{
                    
                    response.Data = null;
                    response.Error = true;
                    response.Message = "No se encontraron datos";
                }

                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }      
        }
    } 
}