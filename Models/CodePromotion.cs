using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class CodePromotion
    {
        public CodePromotion()
        {
            CustomerCodePromotion = new HashSet<CustomerCodePromotion>();
        }

        public int CodePromotionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public decimal? DiscountRate { get; set; }
        public string Description { get; set; }
        public string State { get; set; }

        public virtual ICollection<CustomerCodePromotion> CustomerCodePromotion { get; set; }
    }
}
