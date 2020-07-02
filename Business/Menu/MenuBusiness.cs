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
            try{
                ResultResponse<List<MenuResponse>> response = new ResultResponse<List<MenuResponse>>();
                var result = _context.Menu.ToList().Select( x => new MenuResponse{
                    MenuId = x.MenuId,
                    Name = x.Name,
                    Description = x.Description,
                    CollaboratorId = x.CollaboratorId,
                    Price = x.Price,
                    State = x.State,
                    QuantityMenuCurrent = x.QuantityMenuCurrent,
                    MenuTypeId = x.MenuTypeId,
                    Photos = _context.Photo.Where(y => y.MenuId == x.MenuId).Select(
                        y => new PhotoResponse {
                            PhotoId = y.PhotoId,
                            UrlPhoto = y.UrlPhoto,
                            State = y.State,
                            IsMain = y.IsMain
                        }
                    ).ToList()
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
                        MenuTypeId = result.MenuTypeId,
                        Photos = _context.Photo.Where(y=>y.MenuId == result.MenuId).Select(
                            y => new PhotoResponse {
                                PhotoId = y.PhotoId,
                                UrlPhoto = y.UrlPhoto,
                                State = y.State,
                                IsMain = y.IsMain
                            }
                        ).ToList()
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

        /**CREATE ORDER AND SHOP CAR**/     
        public ResultResponse<string> AddOrderAndMenus(BDHomeFoodContext _context, OrderShopEntity model){
            try
            {
                ResultResponse<string> response = new ResultResponse<string>();
               if(model.LstMenu == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Agrega Menus Al Carrito";
                    return response;
                }
               
                var menuId = model.LstMenu[0].MenuId;
                var collaboratorId = _context.Menu.FirstOrDefault(x => x.MenuId == menuId).CollaboratorId;

                using (var ts = new TransactionScope()){
                    //CREATE ORDER 
                    Order order = new Order();
                    _context.Order.Add(order);

                    order.State = ConstantHelpers.EstadoCompra.Comprado;
                    order.CustomerId = model.CustomerId;
                    order.CollaboratorId = collaboratorId;
                    order.TotalCost = 0;
                    order.TotalCostOrder = 0;
                    order.TotalCostDriver = 0;

                    _context.SaveChanges();

                    //CREATE MENU
                    foreach(var item in model.LstMenu){
                        Models.ShopCar shopCar = new Models.ShopCar();

                        _context.ShopCar.Add(shopCar);

                        shopCar.CustomerId = model.CustomerId;
                        shopCar.MenuId = item.MenuId;
                        shopCar.Quantity = item.QuantityMenuCurrent;

                        var menu = _context.Menu.FirstOrDefault(x=>x.MenuId == item.MenuId);

                        shopCar.Price = menu.Price * item.QuantityMenuCurrent;
                        shopCar.OrderId = order.OrderId;
                        shopCar.State = ConstantHelpers.Estado.Activo;

                        _context.SaveChanges();
                    }

                    var listShopCarOrder = _context.ShopCar.Where(x=>x.OrderId == order.OrderId).ToList();
                    
                    order.TotalCost = listShopCarOrder.Sum(x => x.Price);
                    _context.SaveChanges();

                    response.Data = null;
                    response.Error = false;
                    response.Message = "Venta Realizada con Exito";

                    ts.Complete();
                }
                return response;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
        /****/
   } 
}