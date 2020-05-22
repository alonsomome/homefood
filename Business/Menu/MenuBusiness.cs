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

        public ResultResponse<string> AddMenuCarShop(BDHomeFoodContext _context, ShopCarEntity model){
            try
            {
                ResultResponse<string> response = new ResultResponse<string>();
                if(model.MenuId == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Es necesario agregar un menu la carrito";
                    return response;
                }
                if(model.Quantity == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Es necesario agregar una cantidad por cada menú";
                    return response;
                }

                using (var ts = new TransactionScope()){
                    ShopCar shopCar = new ShopCar();

                    _context.ShopCar.Add(shopCar);

                    shopCar.CustomerId = model.CustomerId;
                    shopCar.MenuId = model.MenuId;
                    shopCar.Quantity = model.Quantity;

                    var menu = _context.Menu.FirstOrDefault(x=>x.MenuId == model.MenuId);

                    shopCar.Price = menu.Price * model.Quantity;
                    shopCar.OrderId = model.OrderId;

                    _context.SaveChanges();
                    
                    response.Data = null;
                    response.Error = false;
                    response.Message = "Menu guardado en carrito con éxito";

                    ts.Complete();
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