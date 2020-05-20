using System;

namespace HomeFood.Entities.Login
{
    public class CustomerEntity
    {
        public string Names{set;get;}
        public string LastNames{set;get;}
        public string DocumentIdentity{set;get;}
        public string Email{set;get;}
        public string Phone{set;get;}
        public DateTime BirthDate{set;get;}
        public string Username{set;get;}
        public String Password{set;get;}
        public Decimal? Latitude{set;get;}
        public Decimal? Longitue{set;get;}
    }
}