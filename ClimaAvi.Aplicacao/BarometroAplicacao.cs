using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Aplicacao
{
    public class BarometroAplicacao
    {
        IBarometroRepository barometroRepository;

        public BarometroAplicacao(IBarometroRepository barometroRepository) {
            this.barometroRepository = barometroRepository;
        }

        public Guid CadastrarBarometro(Barometro barometro) {

            return new Guid();
        }

    }
}
