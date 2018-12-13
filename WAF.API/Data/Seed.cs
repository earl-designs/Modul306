using System.Collections.Generic;
using Newtonsoft.Json;
using WAF.API.Models;

namespace WAF.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedData(){
            SeedPaymentOptions();
            SeedBusinessTypes();
            SeedOpeningTimes();
            SeedBusinessData();
            SeedUsers();
        }

        public void SeedPaymentOptions(){
            var paymentData = System.IO.File.ReadAllText("Database/SeedData/PaymentTypeSeedData.json");
            var paymentOptions = JsonConvert.DeserializeObject<List<PaymentOption>>(paymentData);

            foreach(var paymentOption in paymentOptions){
                _context.Add(paymentOption);
            }
            _context.SaveChanges();
        }

        public void SeedBusinessTypes(){
            var BusinessData = System.IO.File.ReadAllText("Database/SeedData/BusinesTypeSeedData.json");
            var BusinessTypes = JsonConvert.DeserializeObject<List<BusinessType>>(BusinessData);

            foreach(var BusinessType in BusinessTypes){
                _context.Add(BusinessTypes);
            }
            _context.SaveChanges();
        }

        public void SeedOpeningTimes(){
            var OpeningData = System.IO.File.ReadAllText("Database/SeedData/OpeningTimeSeedData.json");
            var OpeningTimes = JsonConvert.DeserializeObject<List<OpeningTime>>(OpeningData);

            foreach(var OpeningTime in OpeningTimes){
                _context.Add(OpeningTime);
            }
            _context.SaveChanges();
        }

        public void SeedBusinessData(){
            var BusinessData = System.IO.File.ReadAllText("Database/SeedData/BusinessSeedData.json");
            var Businesses = JsonConvert.DeserializeObject<List<Business>>(BusinessData);

            foreach(var Business in Businesses)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                
                Business.PasswordHash = passwordHash;
                Business.PasswordSalt = passwordSalt;
                Business.Username = Business.Username.ToLower();

                Business.BusinessType = _context.BusinessType.Find(1);

                Business.PaymentOptions.Add(_context.PaymentOption.Find(1));
                Business.PaymentOptions.Add(_context.PaymentOption.Find(2));

                Business.OpeningTimes.Add(_context.OpeningTime.Find(1));
                Business.OpeningTimes.Add(_context.OpeningTime.Find(2));

                _context.Add(Business);
            }
            _context.SaveChanges();
        }

        public void SeedUsers(){
            var userData = System.IO.File.ReadAllText("Database/SeedData/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users) 
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.User.Add(user);
            }
            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}