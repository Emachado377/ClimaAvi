using System;

namespace ClimaAvi.Models
{
    public class Plant
    {
        public Guid Id { get;}
        public int CodigoPlanta { get; set; }
        public string NomePlanta { get; set; }
        public string LocalPlanta { get; set; }

        public Plant()
        {
            Id = Guid.NewGuid();
        }

        public Plant(int codigoPlanta, string nomePlanta, string localPlanta)
        {
            CodigoPlanta = codigoPlanta;
            NomePlanta = nomePlanta;
            LocalPlanta = localPlanta;
        }
    }
}