using System;
using System.Collections.Generic;

namespace HomeFood.Response
{
    public class CollaboratorResponse
    {
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
        //public int? CollaboratorTypeId { get; set; }
        public string UrlPhoto { get; set; }
        public string State { get; set; }
        public string StateActivity { get; set; }        

        public List<CollaboratorTypeResponse> CollaboratorType {get;set;} = new List<CollaboratorTypeResponse>();        
    }
}