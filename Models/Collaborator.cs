using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class Collaborator
    {
        public Collaborator()
        {
            Menu = new HashSet<Menu>();
            OrderCollaborator = new HashSet<Order>();
            OrderCollaboratorDriver = new HashSet<Order>();
        }

        public int CollaboratorId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string DocumentIdentity { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? CollaboratorTypeId { get; set; }
        public string UrlPhoto { get; set; }
        public string State { get; set; }
        public string StateActivity { get; set; }

        public virtual CollaboratorType CollaboratorType { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<Order> OrderCollaborator { get; set; }
        public virtual ICollection<Order> OrderCollaboratorDriver { get; set; }
    }
}
