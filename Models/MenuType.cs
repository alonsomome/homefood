using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class MenuType
    {
        public MenuType()
        {
            Menu = new HashSet<Menu>();
        }

        public int MenuTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
    }
}
