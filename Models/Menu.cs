using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Photo = new HashSet<Photo>();
            ShopCar = new HashSet<ShopCar>();
        }

        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CollaboratorId { get; set; }
        public decimal? Price { get; set; }
        public string State { get; set; }
        public int? QuantityMenuCurrent { get; set; }
        public int? MenuTypeId { get; set; }

        public virtual Collaborator Collaborator { get; set; }
        public virtual MenuType MenuType { get; set; }
        public virtual ICollection<Photo> Photo { get; set; }
        public virtual ICollection<ShopCar> ShopCar { get; set; }
    }
}
