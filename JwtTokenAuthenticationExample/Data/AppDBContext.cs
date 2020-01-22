using JwtTokenAuthenticationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwtTokenAuthenticationExample.Data
{
    public static class AppDBContext
    {
        private static doantestEntities entity = null;
       

        public static doantestEntities getEntity()
        {
            if (entity == null) entity = new doantestEntities();
            return entity;
        }

    }
}