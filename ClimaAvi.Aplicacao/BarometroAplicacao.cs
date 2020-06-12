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

        public Guid Cadastrarbarometro(Barometro barometro)
        {
            if (true)
            {
                // Validar AQUI se o formato recebido da data e hora são validos e se a entrada não é null
            }

            if (this.barometroRepository.Selecionar(barometro.Id) == null)
            {
                barometro.Id = Guid.NewGuid();
                return this.barometroRepository.Inserir(barometro);
            }
            else
            {
                return this.barometroRepository.Alterar(barometro);
            }
        }

        public void Excluir(Guid id)
        {
            this.barometroRepository.Excluir(id);
        }

        public Barometro Selecionar(Guid id)
        {
            return this.barometroRepository.Selecionar(id);
        }

        public List<Barometro> SelecionarTodos()
        {
            return this.barometroRepository.SelecionarTodos();
        }

    }
}
