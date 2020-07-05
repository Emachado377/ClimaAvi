using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;

namespace ClimaAvi.Aplicacao
{
    public class SensorGasAplicacao
    {
        ISensorGasRepository sensorGasRepository;

        public SensorGasAplicacao(ISensorGasRepository sensorGasRepository)
        {
            this.sensorGasRepository = sensorGasRepository;
        }


        public Guid CadastrarSensorGas(SensorGas sensorGas)
        {

            sensorGas.Id = Guid.NewGuid();
            return this.sensorGasRepository.Inserir(sensorGas);

        }

        public void Excluir(Guid id)
        {
            this.sensorGasRepository.Excluir(id);
        }

        public SensorGas Selecionar(Guid id)
        {
            return this.sensorGasRepository.Selecionar(id);
        }

        public List<SensorGas> SelecionarTodos(Guid id, DateTime dataInicial, DateTime dataFinal)
        {
            return this.sensorGasRepository.SelecionarTodos(id, dataInicial, dataFinal);
        }

    }
}
