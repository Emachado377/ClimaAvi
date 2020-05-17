using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Models
{
    public class Planta
    {
        public Guid Id { get; }

        [Display(Name = "Codigo")]
        [Range(minimum: 1, maximum: 50, ErrorMessage = "Codigo deve ser entre 1 e 50")]
        public int CodigoPlanta { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Nome deve ser preenchido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Nome deve ter entre 4 e 50 caracteres!")]
        public string NomePlanta { get; set; }

        [Display(Name = "Local")]
        [Required(ErrorMessage = "Campo Nome deve ser preenchido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Nome deve ter entre 4 e 50 caracteres!")]
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