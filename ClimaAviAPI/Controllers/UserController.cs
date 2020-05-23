using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClimaAviAPI.Controllers
{
    public class UserController : ApiController
    {
        public static List<User> users = new List<User>();
        
        public UserController() {
            User user1 = new User()
            {
                Code = 1,
                Name = "Evandro",
                Email = "evandro@gmail.com",
                LastName = "Machado",
                Password = "1111",
            };

            User user2 = new User()
            {
                Code = 2,
                Name = "Ruan",
                Email = "ruan@gmail.com",
                LastName = "Ferreira",
                Password = "2222",
            };

            users.Add(user1);
            users.Add(user2);
        }

        // GET api/user
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        // GET api/user/5
        public HttpResponseMessage Get(String id)
        {
            Guid aux;
            aux = Guid.Parse(id);
            try
            {
                foreach (var user in users)
                {
                    if (user.Id == aux)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, user);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/user
        public HttpResponseMessage Post([FromBody]User user)
        {
            try
            {
                if (user.Email == string.Empty || user.Password == string.Empty)
                {
                    throw new ApplicationException("Por favor preencha os campos corretamente");
                }

                users.Add(user);
                return Request.CreateResponse(HttpStatusCode.OK, user.Id);
            }
            catch (ApplicationException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // PUT api/user/5
        [HttpPut]
        public HttpResponseMessage Put(String id, [FromBody]User userBody)
        {
            Guid guidId;
            guidId = Guid.Parse(id);
            var found = false;
            var aux = users;
            try
            {
                foreach (var user in aux)
                {
                    if (user.Id == guidId)
                    {
                        user.Code = userBody.Code;
                        user.Name = userBody.Name;
                        user.LastName = userBody.LastName;
                        user.Email = userBody.Email;
                        user.Password = userBody.Password;
                        found = true;
                    }
                }
                if (found)
                {
                    users = aux;
                    return Request.CreateResponse(HttpStatusCode.OK, guidId);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // DELETE api/user/5
        public HttpResponseMessage Delete(String id)
        {
            Guid guidId;
            guidId = Guid.Parse(id);
            var found = false;
            var aux = users;
            try
            {
                foreach (var user in aux)
                {
                    if (user.Id == guidId)
                    {
                        aux.Remove(user);
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    users = aux;
                    return Request.CreateResponse(HttpStatusCode.OK, guidId);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
