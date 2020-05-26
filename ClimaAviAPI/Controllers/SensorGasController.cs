using ClimaAviAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClimaAviAPI.Controllers
{
    public class SensorGasController : ApiController
    { 
         public static List<SensorGas> listaGas = new List<SensorGas>();

        public SensorGasController()
        {
            var Altit = 200;
            var Temp = 23;
            var Pressao = 1020;
            var Umid = 20;
            var Soma = 1;

            for (var i = 0; i < 5; i++)
            {
                SensorGas sensorGas_i = new SensorGas()
                {
                    Id = Guid.NewGuid(),
                    Metano = Altit + Soma,
                    Propeno = Temp + Soma,
                    Hidrogenio = Pressao + Soma,
                    Fumaca = Umid + Soma,
                    LeituraGas = DateTime.Now,
                };
                listaGas.Add(sensorGas_i);
                Soma = Soma + 1;
            }

        }

        // GET api/barometro
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, listaGas);
        }

        // GET api/barometro
        public HttpResponseMessage Get(String id)
        {
            Guid aux;
            aux = Guid.Parse(id);
            try
            {
                foreach (var busca in listaGas)
                {
                    if (busca.Id == aux)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, busca);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/barometro
        public HttpResponseMessage Post([FromBody]SensorGas sensorGas)
        {
            try
            {
                if (sensorGas.LeituraGas == null)
                {
                    throw new ApplicationException("");
                }

                listaGas.Add(sensorGas);

                return Request.CreateResponse(HttpStatusCode.OK, sensorGas.Id);
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

        // PUT api/barometro
        public HttpResponseMessage Put(String id, [FromBody]SensorGas sensorGasBody)
        {
            Guid guidId;
            guidId = Guid.Parse(id);
            var found = false;
            var aux = listaGas;
            try
            {
                foreach (var busca in aux)
                {
                    if (busca.Id == guidId)
                    {
                        busca.Metano = sensorGasBody.Metano;
                        busca.Propeno = sensorGasBody.Propeno;
                        busca.Hidrogenio = sensorGasBody.Hidrogenio;
                        busca.Fumaca = sensorGasBody.Fumaca;
                        busca.LeituraGas = sensorGasBody.LeituraGas;
                        busca.MacHost = sensorGasBody.MacHost;
                        found = true;
                    }
                }
                if (found)
                {
                    listaGas = aux;
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
            var aux = listaGas;
            try
            {
                foreach (var busca in aux)
                {
                    if (busca.Id == guidId)
                    {
                        aux.Remove(busca);
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    listaGas = aux;
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