using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Persistencia
{
    public class PlantaRepository : IPlantaRepository
    {
        public Guid Alterar(Planta planta)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            
        }

        public Guid Inserir(Planta planta)
        {
           
            return planta.Id;

        }

        public Planta Selecionar(Guid id)
        {
            Planta planta = new Planta();

           return planta;
        }

        public List<Planta> SelecionarTodos()
        {
            List<Planta> plts = null;
            return plts;
        }
    }
}
