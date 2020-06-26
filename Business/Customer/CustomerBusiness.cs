using System;
using System.Linq;
using HomeFood.Models;
using HomeFood.Response;

namespace HomeFood.Business.Customer
{
    public class CustomerBusiness
    {
        public ResultResponse<CustomerResponse> getOrderByCustomerId(BDHomeFoodContext _context,int costumerid)
        {
            try
            {
                ResultResponse<CustomerResponse> response = new ResultResponse<CustomerResponse>();
                var firstresult = _context.Customer.Any(c => c.CustomerId == costumerid);
                if(firstresult)
                {
                  var result = _context.Customer.FirstOrDefault(c=>c.CustomerId ==costumerid );
                  CustomerResponse customerResponse = new CustomerResponse
                  {
                      CustomerId = result.CustomerId,
                      Names = result.Names,
                      LastNames = result.LastNames,
                      DocumentoIdentity = result.DocumentoIdentity,
                      Email = result.Email,
                      Phone =result.Phone,
                      Birthdate = result.Birthdate,
                      Username = result.Username,
                      State = result.State,
                      CreateDate = result.CreateDate,
                      UpdateDate = result.UpdateDate,
                      Order = _context.Order.Where(x =>x.CustomerId == result.CustomerId).Select(
                          x=> new OrderResponse
                          {
                              OrderId = x.OrderId,
                              TotalCost = x.TotalCost,
                              TotalCostOrder = x.TotalCostOrder,
                              TotalCostDriver = x.TotalCostDriver,
                              PaymentDate = x.PaymentDate,
                              State = x.State,
                              CollaboratorDriverId = x.CollaboratorDriverId,
                              Collected = x.Collected,
                              OnMyWay = x.OnMyWay,
                              Deliverred = x.Deliverred,
                              Received = x.Received,
                              PayTypeId = x.PayTypeId,
                              CustomerCodePromotionId = x.CustomerCodePromotionId,
                              CustomerId = x.CustomerId,
                              Collaborator = _context.Collaborator.Where(y=>y.CollaboratorId == x.CollaboratorId).Select(
                                  y => new CollaboratorResponse
                                  {
                                      CollaboratorId = y.CollaboratorId,
                                      Names = y.Names,
                                      LastNames = y.LastNames,
                                      DocumentIdentity = y.DocumentIdentity,
                                      Email = y.Email,
                                      Phone = y.Phone,
                                      BirthDate = y.BirthDate,
                                      Username = y.Username,
                                      Latitude = y.Latitude,
                                      Longitude= y.Longitude,
                                      UrlPhoto = y.UrlPhoto,
                                      State = y.State,
                                      StateActivity = y.StateActivity,
                                      CollaboratorType = _context.CollaboratorType.Where(z =>z.CollaboratorTypeId == y.CollaboratorTypeId).Select(
                                          z => new CollaboratorTypeResponse{
                                              CollaboratorTypeId = z.CollaboratorTypeId,
                                              Name = z.Name,
                                              Description = z.Description
                                          }).ToList()                                                                               
                                 }).ToList()
                        }
                    ).ToList()                
                  };
                    response.Data = customerResponse;
                    response.Error = false;
                    response.Message = "Datos encontrados";

                }
                else
                {
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