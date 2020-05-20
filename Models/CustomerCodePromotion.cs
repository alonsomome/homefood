using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class CustomerCodePromotion
    {
        public CustomerCodePromotion()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerCodePromotionId { get; set; }
        public int? CodePromotionId { get; set; }
        public DateTime? UseDate { get; set; }
        public string State { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual CodePromotion CodePromotion { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
