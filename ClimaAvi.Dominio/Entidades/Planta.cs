using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Dominio.Entidades
{
    public class Planta
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Codigo")]
        public int CodigoPlanta { get; set; }

        [Display(Name = "Nome")]
        public string NomePlanta { get; set; }

        [Display(Name = "Local")]
        public string LocalPlanta { get; set; }

        [Display(Name = "Endereço Mac")]
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