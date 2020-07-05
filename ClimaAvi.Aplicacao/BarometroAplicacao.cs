using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Aplicacao
{
    public class BarometroAplicacao
    {
        IBarometroRepository barometroRepository;

        public BarometroAplicacao(IBarometroRepository barometroRepository)
        {
            this.barometroRepository = barometroRepository;
        }

        public Guid CadastrarBarometro(Barometro barometro)
        {

            barometro.Id = Guid.NewGuid();
            return this.barometroRepository.Inserir(barometro);

        }

        public void Excluir(Guid id)
        {
            this.barometroRepository.Excluir(id);
        }

        public Barometro Selecionar(Guid id)
        {
            return this.barometroRepository.Selecionar(id);
        }

        public List<Barometro> SelecionarTodos(Guid id, DateTime dataInicial, DateTime dataFinal)
        {
            return this.barometroRepository.SelecionarTodos(id, dataInicial, dataFinal);
        }

    }
}
