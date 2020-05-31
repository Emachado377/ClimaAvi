using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Persistencia
{
    public class BarometroRepository : IBarometroRepository
    {
        public Guid Alterar(Barometro barometro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid Inserir(Barometro barometro)
        {
            throw new NotImplementedException();
        }

        public Barometro Selecionar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Barometro> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
