using JwtTokenAuthenticationExample.Auth;
using JwtTokenAuthenticationExample.Data;
using JwtTokenAuthenticationExample.Models;
using JwtTokenAuthenticationExample.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace JwtTokenAuthenticationExample.Controllers
{
    public class RequestTokenController : ApiController
    {
        doantestEntities entity;
        public RequestTokenController()
        {      
            this.entity = AppDBContext.getEntity();
        }

        [HttpPost]
        public HttpResponseMessage CreateToken([FromBody] UserDTO userDTO)
        {
            string username = null, password = null, clientId = null;
            username = userDTO.UserName;
            password = userDTO.UserPassword;
            clientId = userDTO.ClientID;

            if (CheckUser(username, password))
            {
                return Request.CreateResponse(HttpStatusCode.OK,JwtAuthManager.GenerateJWTToken(username));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized,"Invalid Request");
            }
        }
        public bool CheckUser(string username, string password)
        {
            ICollection<UserDTO> users = entity.UserMaster.Where(e => e.UserPassword == password && e.UserName == username).Select(e => new UserDTO { UserName = e.UserName, UserPassword = e.UserPassword }).ToList();
            UserDTO user = users.ElementAt(0);

            if (username == user.UserName && password == user.UserPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
