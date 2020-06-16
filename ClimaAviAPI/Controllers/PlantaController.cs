using ClimaAvi.Aplicacao;
using ClimaAvi.Models;
using ClimaAvi.Persistencia;
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

        public HttpResponseMessage Get()
        {
            PlantaRepository plantaRepository = new PlantaRepository();
            PlantaAplicacao plantaAplicacao = new PlantaAplicacao(plantaRepository);
            List<Planta> plantas = new List<Planta>();

            var plts = plantaAplicacao.SelecionarTodos();

            foreach (var busca in plts)
            {
                plantas.Add(new Planta()
                {
                    Id = busca.Id,
                    CodigoPlanta = busca.CodigoPlanta,
                    NomePlanta = busca.NomePlanta,                    
                    LocalPlanta = busca.LocalPlanta,
                    MacHost = busca.MacHost
                }); 
            }
            return Request.CreateResponse(HttpStatusCode.OK, plantas);
        }

        // GET api/values/5
        public HttpResponseMessage Get(Guid id)
        {
            PlantaRepository plantaRepository = new PlantaRepository();
            PlantaAplicacao plantaAplicacao = new PlantaAplicacao(plantaRepository);                            

            try
            {
                var plt = Procurar(id);
               
                if (plt.Id == id)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, plt);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                //falha é trata aqui
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] Planta planta)
        {           
            try
            {
                Guid id = Inserir(planta);
                               
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

        private Guid Inserir(Planta planta)
        {
            PlantaRepository plantaRepository = new PlantaRepository();
            PlantaAplicacao plantaAplicacao = new PlantaAplicacao(plantaRepository);

            //Adapter
            ClimaAvi.Dominio.Entidades.Planta plt_Dominio = new ClimaAvi.Dominio.Entidades.Planta()
            {
                Id = planta.Id,
                CodigoPlanta = planta.CodigoPlanta,
                NomePlanta = planta.NomePlanta,
                LocalPlanta = planta.LocalPlanta,
                MacHost = planta.MacHost
            };

            var id = plantaAplicacao.CadastrarPlanta(plt_Dominio);

            return id;

        }

        // PUT api/values/5
        public HttpResponseMessage Put(Guid id, [FromBody] Planta planta)
        {
            try
            {
                var plt = Procurar(id);
                if (plt != null)
                {
                    Guid id_planta = Alterar(planta);
                    return Request.CreateResponse(HttpStatusCode.OK, id_planta);
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

        private Guid Alterar(Planta planta)
        {
            PlantaRepository plantaRepository = new PlantaRepository();
            PlantaAplicacao plantaAplicacao = new PlantaAplicacao(plantaRepository);

            //Adapter
            ClimaAvi.Dominio.Entidades.Planta plt_Dominio = new ClimaAvi.Dominio.Entidades.Planta()
            {
                Id = planta.Id,
                CodigoPlanta = planta.CodigoPlanta,
                NomePlanta = planta.NomePlanta,
                LocalPlanta = planta.LocalPlanta,
                MacHost = planta.MacHost
            };

            var id = plantaAplicacao.CadastrarPlanta(plt_Dominio);

            return id;
        }

        private Planta Procurar(Guid id_Planta)
        {
            PlantaRepository plantaRepository = new PlantaRepository();
            PlantaAplicacao plantaAplicacao = new PlantaAplicacao(plantaRepository);

            var plt = plantaAplicacao.Selecionar(id_Planta);

            return new Planta()
            {
                Id = plt.Id,
                CodigoPlanta = plt.CodigoPlanta,
                NomePlanta = plt.NomePlanta,
                LocalPlanta = plt.LocalPlanta,
                MacHost = plt.MacHost
            };
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Excluir(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private void Excluir(Guid id_Planta)
        {
            PlantaRepository plantaRepository = new PlantaRepository();
            PlantaAplicacao plantaAplicacao = new PlantaAplicacao(plantaRepository);
            plantaAplicacao.Excluir(id_Planta);
        }
    }
}

