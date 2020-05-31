using System;

namespace ClimaAvi.Dominio.Entidades
{
    public class Planta
    {
        public Guid Id { get; }

        public int CodigoPlanta { get; set; }

        public string NomePlanta { get; set; }

        public string LocalPlanta { get; set; }
        public string MacHost { get; set; }

        public Planta()
        {
            Id = Guid.NewGuid();
        }

        public Planta(int codigoPlanta, string nomePlanta, string localPlanta, string macPlanta)
        {
            CodigoPlanta = codigoPlanta;
            NomePlanta = nomePlanta;
            LocalPlanta = localPlanta;
            MacHost = macPlanta;
        }
    }
}