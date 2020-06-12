using ClimaAvi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Persistencia
{
    public class ContextoSeeInitializer : DropCreateDatabaseAlways
      <Contexto>
    {
        // Identifica se existe o BD e então cria uma novo.
        protected override void Seed(Contexto context)
        {
        }
    }
    public class Contexto : DbContext
    {
        public Contexto() : base("BDClimaAvi") { }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Barometro> Barometros { get; set; }
        public DbSet<SensorGas> SensorGass { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
