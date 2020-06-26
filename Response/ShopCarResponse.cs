using System.Collections.Generic;

namespace HomeFood.Response
{
    public class ShopCarResponse
    {
        public int ShopCarId { get; set; }
        public int? CustomerId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string State { get; set; }

        public List<OrderResponse> Order {get;set;} = new List<OrderResponse>();
        public List<MenuResponse> Menu {get;set;} = new List<MenuResponse>();

        

    }
}