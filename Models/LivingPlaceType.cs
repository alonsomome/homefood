using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class LivingPlaceType
    {
        public LivingPlaceType()
        {
            Address = new HashSet<Address>();
        }

        public int LivingPlaceTypeId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
