
using ClimaAvi.Dominio.Entidades;
using ClimaAviAPI.Contexts;
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
        // GET api/user
        public HttpResponseMessage Get()
        {
            UserContext userContext = new UserContext();
            return Request.CreateResponse(HttpStatusCode.OK, userContext.Users.ToList());
        }

        // GET api/user/5
        public HttpResponseMessage Get(String id)
        {
            Guid aux;
            aux = Guid.Parse(id);
            UserContext userContext = new UserContext();
            try
            {
                User userFind = userContext.Users.Find(aux);
                if (!(userFind == null))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, userFind);
                }
                else {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
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

                UserContext userContext = new UserContext();
                userContext.Users.Add(user);
                userContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, user.Id);
            }
            catch (ApplicationException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }

        }

        // PUT api/user/5
        [HttpPut]
        public HttpResponseMessage Put(String id, [FromBody]User userBody)
        {
            Guid guidId;
            guidId = Guid.Parse(id);
            UserContext userContext = new UserContext();

            try
            {
                User userFind = userContext.Users.Find(guidId);
                if (!(userFind == null))
                {
                    userFind.Code = userBody.Code == 0 ? userFind.Code : userBody.Code;
                    userFind.Name = userBody.Name== null ? userFind.Name : userBody.Name;
                    userFind.LastName = userBody.LastName == null ? userFind.LastName : userBody.LastName;
                    userFind.Email = userBody.Email == null ? userFind.Email : userBody.Email;
                    userFind.Password = userBody.Password == null ? userFind.Password : userBody.Password;
                    userContext.SaveChanges();


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

            UserContext userContext = new UserContext();
        
            try
            {
                User userFind = userContext.Users.Find(guidId);
                if (!(userFind == null))
                {
                    userContext.Users.Remove(userFind);
                    userContext.SaveChanges();
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
