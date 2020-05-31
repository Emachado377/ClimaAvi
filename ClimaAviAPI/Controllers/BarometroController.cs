using ClimaAvi.Models;
using ClimaAviAPI.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace ClimaAviAPI.Controllers
{
    public class BarometroController : ApiController
    {
        public static List<Barometro> listaBarometro = new List<Barometro>();
        private IEnumerable<Planta> plantas;

        public BarometroController()
        {           
            var Altit = 200;
            var Temp = 23;
            var Pressao = 1020;
            var Umid = 20;
            var Soma = 1;

            for (var i = 0; i < 5; i++)
            {               
                Barometro barometro_i = new Barometro()
                {
                    Id = Guid.NewGuid(),
                    Altitude = Altit + Soma,
                    Temperatura = Temp + Soma,
                    PressaoAtmosferica = Pressao + Soma,
                    UmidadeAr = Umid + Soma,
                    LeituraBarometro = DateTime.Now,
                    MacHost = "2CC",
                };
                listaBarometro.Add(barometro_i);
                Soma = Soma + 1;
            }

        }

        // GET api/barometro
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, listaBarometro);
        }

        // GET api/barometro
        public HttpResponseMessage Get(String id)
        {
            Guid aux;
            aux = Guid.Parse(id);
            try
            {
                foreach (var busca in listaBarometro)
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
        public HttpResponseMessage Post([FromBody]Barometro barometro)
        {
            //List<Planta> plantas = new List<Planta>();
            //plantas = (List<Planta>)Session["planta"]; 

            // Como chamar uma lista de outra controller ou da global.asax ?
            try
            {
                if (barometro.LeituraBarometro == null || barometro.MacHost == null)
                {
                    throw new ApplicationException("Horario não informado ou Mac Invalido");
                }
                else
                {
                    foreach (var busca in plantas)// falta definir a forma para chamar a lista de Plantas
                    {
                        if (busca.MacHost == barometro.MacHost)
                        {
                            listaBarometro.Add(barometro);
                            return Request.CreateResponse(HttpStatusCode.OK, barometro.Id);
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
        public HttpResponseMessage Put(String id, [FromBody]Barometro barometroBody)
        {
            Guid guidId;
            guidId = Guid.Parse(id);
            var found = false;
            var aux = listaBarometro;
            try
            {
                foreach (var busca in aux)
                {
                    if (busca.Id == guidId)
                    {
                        busca.Altitude = barometroBody.Altitude;
                        busca.Temperatura = barometroBody.Temperatura;
                        busca.PressaoAtmosferica = barometroBody.PressaoAtmosferica;
                        busca.UmidadeAr = barometroBody.UmidadeAr;
                        busca.LeituraBarometro = barometroBody.LeituraBarometro;
                        busca.MacHost = barometroBody.MacHost;
                        found = true;
                    }
                }
                if (found)
                {
                    listaBarometro = aux;
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
            var aux = listaBarometro;
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
                    listaBarometro = aux;
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
