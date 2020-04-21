using System;

namespace ClimaAvi.Models
{
    public class Planta
    {
        public Guid Id { get;}
        public int CodigoPlanta { get; set; }
        public string NomePlanta { get; set; }
        public string LocalPlanta { get; set; }

        public Planta()
        {
            Id = Guid.NewGuid();
        }

        public Planta(int codigoPlanta, string nomePlanta, string localPlanta)
        {
            CodigoPlanta = codigoPlanta;
            NomePlanta = nomePlanta;
            LocalPlanta = localPlanta;
        }
    }
}