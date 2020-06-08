using ClimaAvi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClimaAviAPI.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext() : base("user") { 
            
        }

        public DbSet<User> Users { get; set; }
    }
}