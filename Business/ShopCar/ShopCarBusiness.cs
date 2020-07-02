using System;
using System.Linq;
using HomeFood.Models;
using HomeFood.Response;

namespace HomeFood.Business.ShopCar
{
    public class ShopCarBusiness
    {
        public ResultResponse<ShopCarResponse> GetByCustomerId (BDHomeFoodContext _context,int costumerid){
            try
            {
                ResultResponse<ShopCarResponse> response = new ResultResponse<ShopCarResponse>();
                var firstresult = _context.ShopCar.Any(c=>c.CustomerId == costumerid);
                if(firstresult){
                    var result = _context.ShopCar.FirstOrDefault(x =>x.CustomerId == costumerid);

                    ShopCarResponse shopCarResponse = new ShopCarResponse{
                        ShopCarId = result.ShopCarId,
                        CustomerId = result.CustomerId,
                        Quantity = result.Quantity,
                        Price = result.Price,
                        State = result.State,
                        Menu = _context.Menu.Where(y =>y.MenuId ==result.MenuId).Select(
                            y=> new MenuResponse{
                                MenuId= y.MenuId,
                                Name = y.Name,
                                Description = y.Description,
                                CollaboratorId = y.CollaboratorId,
                                Price = y.Price,
                                State = y.State,
                                Photos = _context.Photo.Where(z =>z.MenuId == y.MenuId).Select(
                                    z => new PhotoResponse{
                                        PhotoId =z.PhotoId,
                                        UrlPhoto = z.UrlPhoto,
                                        State = z.State,
                                        IsMain = z.IsMain
                                    }
                                ).ToList()
                            }
                        ).ToList(),
                        Order = _context.Order.Where(w=>w.OrderId == result.OrderId).Select(
                            w => new OrderResponse{
                            OrderId = w.OrderId,
                            TotalCost = w.TotalCost,
                            TotalCostOrder = w.TotalCostOrder,
                            TotalCostDriver = w.TotalCostDriver,
                            PaymentDate = w.PaymentDate,
                            State = w.State,
                            CollaboratorDriverId = w.CollaboratorDriverId,
                            Collected = w.Collected,
                            OnMyWay = w.OnMyWay,
                            Deliverred = w.Deliverred,
                            Received = w.Received,
                            PayTypeId = w.PayTypeId,
                            CustomerCodePromotionId = w.CustomerCodePromotionId,
                            CustomerId = w.CustomerId
                            }
                        ).ToList()

                    };
                    response.Data = shopCarResponse;
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