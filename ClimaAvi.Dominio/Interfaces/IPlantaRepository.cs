using ClimaAvi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Dominio.Interfaces
{
    public interface IPlantaRepository
    {
        Planta Selecionar(Guid id);
        List<Planta> SelecionarTodos();
        Guid Inserir(Planta planta);
        Guid Alterar(Planta planta);
        void Excluir(Guid id);
    }
}
