using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwtTokenAuthenticationExample.DTOs
{
  

    public class ClientDTO
    {
   
        public string ClientName { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }

    }
}