using System;
using System.Collections.Generic;

namespace WAF.API.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get ; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreateDate { get; set; } 
        public BusinessType BusinessType { get; set; }
        public string WebLink { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
        public int Plz { get; set; }
        public List<PaymentOption> PaymentOptions { get; set; }
        public List<OpeningTime> OpeningTimes { get; set; }
    }
}