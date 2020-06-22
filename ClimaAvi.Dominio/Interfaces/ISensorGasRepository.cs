using ClimaAvi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Dominio.Interfaces
{
    public interface ISensorGasRepository
    {
        SensorGas Selecionar(Guid id);
        List<SensorGas> SelecionarTodos(Guid id);
        Guid Inserir(SensorGas sensorGas);
        Guid Alterar(SensorGas sensorGas);
        void Excluir(Guid id);
    }
}
