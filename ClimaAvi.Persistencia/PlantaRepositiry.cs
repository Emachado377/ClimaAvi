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
            try
            {
                Contexto db = new Contexto();
                Planta plt = db.Plantas.Find(id);
                db.Plantas.Remove(plt);
                db.SaveChanges();
            }
            catch (DataException)
            {
                throw new NotImplementedException();
            }
        }

        public Guid Inserir(Planta planta)
        {
            try
            {
                Contexto db = new Contexto();
                db.Plantas.Add(planta);
                db.SaveChanges();
            }
            catch (DataException)
            {
                throw new NotImplementedException();

            }
            return planta.Id;

        }

        public Planta Selecionar(Guid id)
        {
           Contexto db = new Contexto();
           Planta plt =  db.Plantas.Find(id);
           return plt;
        }

        public List<Planta> SelecionarTodos()
        {
           Contexto db = new Contexto();
           List<Planta> plts = db.Plantas.ToList();
          // Precisa ser tratada essa Informação ???
            return plts;
        }
    }
}
