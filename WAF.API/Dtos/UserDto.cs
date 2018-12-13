using System;
using System.Collections.Generic;

namespace WAF.API.Dtos
{
    public class UserDto
    {        
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }  

        public string PreName { get; set; }
        public string LastName { get; set; }
    }
}