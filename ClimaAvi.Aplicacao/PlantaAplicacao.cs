using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Aplicacao
{
    public class PlantaAplicacao
    {
        IPlantaRepository plantaRepository;

        public PlantaAplicacao(IPlantaRepository plantaRepository)
        {
            this.plantaRepository = plantaRepository;
        }

        public Guid CadastrarPlanta (Planta planta)
        {
            if (string.IsNullOrEmpty(planta.MacHost))
            {
                throw new ApplicationException("Endereço MAC não informado!");
            }

            if (this.plantaRepository.Selecionar(planta.Id) == null)
            {
                planta.Id = Guid.NewGuid();
                return this.plantaRepository.Inserir(planta);
            }
            else
            {
                return this.plantaRepository.Alterar(planta);
            }
        }

        public void Excluir(Guid id)
        {
            this.plantaRepository.Excluir(id);
        }

        public Planta Selecionar(Guid id)
        {
            return this.plantaRepository.Selecionar(id);
        }

        public List<Planta> SelecionarTodos()
        {
            return this.plantaRepository.SelecionarTodos();
        }

    }
}
