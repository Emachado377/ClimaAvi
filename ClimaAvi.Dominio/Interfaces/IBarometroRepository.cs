using ClimaAvi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Dominio.Interfaces
{
    public interface IBarometroRepository
    {
        Barometro Selecionar(Guid id);
        List<Barometro> SelecionarTodos();
        Guid Inserir(Barometro barometro);
        Guid Alterar(Barometro barometro);
        void Excluir(Guid id);
    }
}
