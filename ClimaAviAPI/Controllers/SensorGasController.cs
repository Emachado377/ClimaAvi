using ClimaAvi.Models;
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

        public object Session { get; private set; }

        public SensorGasController()
        {
            var Met = 3;
            var Prop = 4;
            var Hid = 78;
            var Fum = 1;                
            var Soma = 1;

            for (var i = 0; i < 5; i++)
            {
                SensorGas sensorGas_i = new SensorGas()
                {
                    Id = Guid.NewGuid(),
                    Metano = Met + Soma,
                    Propeno = Prop + Soma,
                    Hidrogenio = Hid + Soma,
                    Fumaca = Fum + Soma,
                    LeituraGas = DateTime.Now,
                    MacHost = "2CC",
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
            //List<Planta> plantas = new List<Planta>();
            //plantas = (List<Planta>)Session["planta"]; 

            // Como chamar uma lista de outra controller ou da global.asax ?

            try
            {
                if (sensorGas.LeituraGas == null || sensorGas.MacHost == null)
                {
                    throw new ApplicationException("Horario não informado ou Mac Invalido");
                }
                else
                {
                    foreach (var busca in plantas)// falta definir a forma para chamar a lista de Plantas
                    {
                        if (busca.MacHost == sensorGas.MacHost)
                        {
                            listaGas.Add(sensorGas);
                            return Request.CreateResponse(HttpStatusCode.OK, sensorGas.Id);
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
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