using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class Order
    {
        public Order()
        {
            ShopCar = new HashSet<ShopCar>();
        }

        public int OrderId { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? TotalCostOrder { get; set; }
        public decimal? TotalCostDriver { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string State { get; set; }
        public int? CollaboratorDriverId { get; set; }
        public bool? Collected { get; set; }
        public bool? OnMyWay { get; set; }
        public bool? Deliverred { get; set; }
        public bool? Received { get; set; }
        public int? PayTypeId { get; set; }
        public int? CustomerCodePromotionId { get; set; }
        public int? CustomerId { get; set; }
        public int? CollaboratorId { get; set; }

        public virtual Collaborator Collaborator { get; set; }
        public virtual Collaborator CollaboratorDriver { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerCodePromotion CustomerCodePromotion { get; set; }
        public virtual ICollection<ShopCar> ShopCar { get; set; }
    }
}
