using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class ShopCar
    {
        public int ShopCarId { get; set; }
        public int? CustomerId { get; set; }
        public int? MenuId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? OrderId { get; set; }
        public string State { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Order Order { get; set; }
    }
}
