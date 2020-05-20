using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Nameaddress { get; set; }
        public string Reference { get; set; }
        public int? LivingPlaceTypeId { get; set; }
        public string DepartmentNum { get; set; }
        public int CustomerId { get; set; }
        public bool? Selected { get; set; }
        public string State { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual LivingPlaceType LivingPlaceType { get; set; }
    }
}
