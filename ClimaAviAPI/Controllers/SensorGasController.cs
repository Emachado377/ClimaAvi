
using ClimaAvi.Aplicacao;
using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Persistencia;
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

        public HttpResponseMessage Get(Guid id, Boolean single, DateTime dataInicial, DateTime dataFinal)
        {
            SensorGasRepository sensorGasRepository = new SensorGasRepository();
            SensorGasAplicacao sensorGasAplicacao = new SensorGasAplicacao(sensorGasRepository);
            List<SensorGas> dados = new List<SensorGas>();


            if (single) {
                var urs = sensorGasAplicacao.Selecionar(id);

                var temp = new SensorGas()
                {
                    Id = urs.Id,
                    Metano = urs.Metano,
                    Propeno = urs.Propeno,
                    Hidrogenio = urs.Hidrogenio,
                    Fumaca = urs.Fumaca,
                    LeituraGas = urs.LeituraGas,
                    MacHostGas = urs.MacHostGas,
                };
                return Request.CreateResponse(HttpStatusCode.OK, temp);
            }
            else {
                var urs = sensorGasAplicacao.SelecionarTodos(id, dataInicial, dataFinal);

                foreach (var busca in urs)
                {
                    dados.Add(new SensorGas()
                    {
                        Id = busca.Id,
                        Metano = busca.Metano,
                        Propeno = busca.Propeno,
                        Hidrogenio = busca.Hidrogenio,
                        Fumaca = busca.Fumaca,
                        LeituraGas = busca.LeituraGas,
                        MacHostGas = busca.MacHostGas,
                    });
                }
                return Request.CreateResponse(HttpStatusCode.OK, dados);
            }
            
        }

      
        // POST api/barometro
        public HttpResponseMessage Post([FromBody]SensorGas sensorGas)
        {
            try
            {
                Guid id = Inserir(sensorGas);
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

        private Guid Inserir(SensorGas sensorGas)
        {
            SensorGasRepository sensorGasRepository = new SensorGasRepository();
            SensorGasAplicacao sensorGasAplicacao = new SensorGasAplicacao(sensorGasRepository);

            //Adapter
            ClimaAvi.Dominio.Entidades.SensorGas sensorGasDominio = new ClimaAvi.Dominio.Entidades.SensorGas()
            {
                Id = Guid.Empty,
                Metano = sensorGas.Metano,
                Propeno = sensorGas.Propeno,
                Hidrogenio = sensorGas.Hidrogenio,
                Fumaca = sensorGas.Fumaca,
                LeituraGas = sensorGas.LeituraGas,
                MacHostGas = sensorGas.MacHostGas,
            };

            var id = sensorGasAplicacao.CadastrarSensorGas(sensorGasDominio);

            return id;
        }

        // PUT api/barometro
        public HttpResponseMessage Put(String id, [FromBody]SensorGas sensorGasBody)
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
            SensorGasRepository sensorGasRepository = new SensorGasRepository();
            SensorGasAplicacao sensorGasAplicacao = new SensorGasAplicacao(sensorGasRepository);
            sensorGasAplicacao.Excluir(id);
        }
    }
}