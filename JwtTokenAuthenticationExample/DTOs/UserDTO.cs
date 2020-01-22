using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwtTokenAuthenticationExample.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string ClientID { get; set; }
    }
}