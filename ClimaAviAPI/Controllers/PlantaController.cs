using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClimaAviAPI.Controllers
{
    public class PlantaController : ApiController
    {
        public static List<Planta> plantas = new List<Planta>();

        public PlantaController()
        {

            Planta planta2 = new Planta()
            {
                CodigoPlanta = 10,
                NomePlanta = "Aviario 1",
                LocalPlanta = "Fazenda Souza",
                MacHost = "2C",
            };
                        
            plantas.Add(planta2);

        }

        // GET api/user
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, plantas);
        }

        // GET api/user/5
        public HttpResponseMessage Get(String id)
        {
            Guid aux;
            aux = Guid.Parse(id);
            try
            {
                foreach (var planta in plantas)
                {
                    if (planta.Id == aux)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, planta);
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
        public HttpResponseMessage Post([FromBody]Planta planta)
        {
            try
            {
                if (planta.CodigoPlanta == null || planta.NomePlanta == string.Empty)
                {
                    throw new ApplicationException("Por favor preencha os campos corretamente");
                }

                plantas.Add(planta);
                return Request.CreateResponse(HttpStatusCode.OK, planta.Id);
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
        public HttpResponseMessage Put(String id, [FromBody]Planta plantaBody)
        {
            Guid guidId;
            guidId = Guid.Parse(id);
            var found = false;
            var aux = plantas;
            try
            {
                foreach (var planta in aux)
                {
                    if (planta.Id == guidId)
                    {
                        planta.CodigoPlanta = plantaBody.CodigoPlanta;
                        planta.NomePlanta = plantaBody.NomePlanta;
                        planta.LocalPlanta = plantaBody.LocalPlanta;
                        planta.MacHost = plantaBody.MacHost;
                        found = true;
                    }
                }
                if (found)
                {
                    plantas = aux;
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
            var aux = plantas;
            try
            {
                foreach (var planta in aux)
                {
                    if (planta.Id == guidId)
                    {
                        aux.Remove(planta);
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    plantas = aux;
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
