using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class Photo
    {
        public int PhotoId { get; set; }
        public string UrlPhoto { get; set; }
        public int MenuId { get; set; }
        public string State { get; set; }
        public bool IsMain { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
