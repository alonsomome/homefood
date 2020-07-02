using System;
using System.Collections.Generic;

namespace HomeFood.Entities.Menu
{
    public class OrderShopEntity
    {
        public int? CustomerId {set;get;}
        public List<MenuEntity> LstMenu { set;get;} = new List<MenuEntity>();
    }
}