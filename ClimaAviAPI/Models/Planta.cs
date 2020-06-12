using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Models
{
    public class Planta
    {
        public Guid Id { get; set; }
        public int CodigoPlanta { get; set; }
        public string NomePlanta { get; set; }
        public string LocalPlanta { get; set; }
        public string MacHost { get; set; }

        public Planta()
        {
            Id = Guid.NewGuid();
        }

        public Planta(int codigoPlanta, string nomePlanta, string localPlanta, string macHost)
        {
            CodigoPlanta = codigoPlanta;
            NomePlanta = nomePlanta;
            LocalPlanta = localPlanta;
            MacHost = macHost;
        }
    }
}