using JwtTokenAuthenticationExample.Auth;
using JwtTokenAuthenticationExample.Data;
using JwtTokenAuthenticationExample.DTOs;
using JwtTokenAuthenticationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace JwtTokenAuthenticationExample.Controllers
{
    public class UserApiController : ApiController
    {
        /*
        [HttpPost]
        public ClientDTO PostClientIdentityWithFormData(FormDataCollection formDataCollection)
        {
            string clientName = null;

            IEnumerator<KeyValuePair<string, string>> pairs = formDataCollection.GetEnumerator();
          
            while (pairs.MoveNext())
            {
                KeyValuePair<string, string> pair = pairs.Current;
                if(pair.Key == "ClientName")
                {
                    clientName = pair.Value;
                }
            }
          
            doantestEntities entity =  AppDBContext.getEntity();
            IQueryable<ClientDTO> clients = entity.ClientMaster.Where(e => e.ClientName == clientName).Select(e => new ClientDTO { ClientID = e.ClientId, ClientSecret = e.ClientSecret });
            ClientDTO client = clients.ElementAt(0);
            return client;
        }
        */
        
        [HttpPost]
        public ClientDTO PostClientIdentityWithJson([FromBody] ClientDTO clientDTO)
        {
            string clientName = null;
            clientName = clientDTO.ClientName;


            doantestEntities entity = AppDBContext.getEntity();
            ICollection<ClientDTO> clients = entity.ClientMaster.Where(e => e.ClientName == clientName).Select(e => new ClientDTO { ClientID = e.ClientId, ClientSecret = e.ClientSecret }).ToList();
            ClientDTO client = clients.ElementAt(0);
            return client;
        }
        
        [JwtAuthentication]
        [HttpGet]
        public HttpResponseMessage RedirectToHome()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            var uriString = "http://localhost:49996/Home/Index";
            response.Headers.Location = new Uri(uriString);
            response.Headers.Add("FORCE_REDIRECT", uriString);
           
            return response;//new HttpResponseMessage(HttpStatusCode.OK);
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
