using ClimaAvi.Aplicacao;
using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Models;
using ClimaAvi.Persistencia;
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
        // GET api/barometro
        public HttpResponseMessage Get(Guid id, Boolean single)
        {
            BarometroRepository barometroRepository = new BarometroRepository();
            BarometroAplicacao barometroAplicacao = new BarometroAplicacao(barometroRepository);
            List<Barometro> dados = new List<Barometro>();

            if (single) {
                var urs = barometroAplicacao.Selecionar(id);

                 var temp = new Barometro()
                {
                     Id = urs.Id,
                     Altitude = urs.Altitude,
                     Temperatura = urs.Temperatura,
                     PressaoAtmosferica = urs.PressaoAtmosferica,
                     UmidadeAr = urs.UmidadeAr,
                     LeituraBarometro = urs.LeituraBarometro,
                     MacHostBarometro = urs.MacHostBarometro,
                 };
                return Request.CreateResponse(HttpStatusCode.OK, temp);
            }
            else {
                var urs = barometroAplicacao.SelecionarTodos(id);

                foreach (var busca in urs)
                {
                    dados.Add(new Barometro()
                    {
                        Id = busca.Id,
                        Altitude = busca.Altitude,
                        Temperatura = busca.Temperatura,
                        PressaoAtmosferica = busca.PressaoAtmosferica,
                        UmidadeAr = busca.UmidadeAr,
                        LeituraBarometro = busca.LeituraBarometro,
                        MacHostBarometro = busca.MacHostBarometro,
                    });
                }
                return Request.CreateResponse(HttpStatusCode.OK, dados);
            }
            
        }


        // POST api/barometro
        public HttpResponseMessage Post([FromBody]Barometro barometro)
        {

            try
            {
                Guid id = Inserir(barometro);
                return Request.CreateResponse(HttpStatusCode.OK, id);
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

        private Guid Inserir(Barometro barometro)
        {
            BarometroRepository barometroRepository = new BarometroRepository();
            BarometroAplicacao barometroAplicacao = new BarometroAplicacao(barometroRepository);

            //Adapter
            ClimaAvi.Dominio.Entidades.Barometro barometroDominio = new ClimaAvi.Dominio.Entidades.Barometro()
            {
                Id = Guid.Empty,
                Altitude = barometro.Altitude,
                Temperatura = barometro.Temperatura,
                PressaoAtmosferica = barometro.PressaoAtmosferica,
                UmidadeAr = barometro.UmidadeAr,
                LeituraBarometro = barometro.LeituraBarometro,
                MacHostBarometro = barometro.MacHostBarometro,
            };

            var id = barometroAplicacao.CadastrarBarometro(barometroDominio);

            return id;
        }

        // PUT api/barometro
        public HttpResponseMessage Put(String id, [FromBody]Barometro barometroBody)
        {

            return Request.CreateResponse(HttpStatusCode.NotFound);

        }

        // DELETE api/user/5
        public HttpResponseMessage Delete(Guid id)
        {

            Excluir(id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        private void Excluir(Guid id)
        {
            BarometroRepository barometroRepository = new BarometroRepository();
            BarometroAplicacao barometroAplicacao = new BarometroAplicacao(barometroRepository);
            barometroAplicacao.Excluir(id);
        }
    }
}
