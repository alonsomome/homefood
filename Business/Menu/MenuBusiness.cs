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

namespace HomeFood.Business
{
    public class MenuBusiness
    {
        public ResultResponse<List<MenuResponse>> GetAllMenu(BDHomeFoodContext _context,MenuEntity model)
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
                
                /*
                MenuResponse menuresp = new MenuResponse
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
                */

                response.Data = result;
                response.Error = false;
                response.Message ="datos encontrados";
                
                return response;
                
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    } 
}