using System;
using System.Collections.Generic;

namespace WAF.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get ; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreateDate { get; set; }

        public string PreName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string tel { get; set; }
        public Address Address {get; set;}
    }
}