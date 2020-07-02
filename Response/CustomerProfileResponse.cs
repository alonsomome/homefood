using System;
using System.Collections.Generic;

namespace HomeFood.Response
{
    public class CustomerProfileResponse
    {
        public int CustomerId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string DocumentoIdentity { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Username { get; set; }
        public string Pasword { get; set; }
        public string State { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }   
    }
}