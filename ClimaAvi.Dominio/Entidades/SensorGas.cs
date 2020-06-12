using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Dominio.Entidades
{
    public class SensorGas
    {
        [Key]
        public Guid Id { get; set; }
        public float Metano { get; set; }
        public float Propeno { get; set; }
        public float Hidrogenio { get; set; }
        public float Fumaca { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime LeituraGas { get; set; }
        public string MacHostGas { get; set; }

        public SensorGas()
        {
        }

        public SensorGas(float metano, float propeno, float hidrogenio, float fumaca, DateTime leituraGas, string macHostGas)
        {
            Metano = metano;
            Propeno = propeno;
            Hidrogenio = hidrogenio;
            Fumaca = fumaca;
            LeituraGas = leituraGas;
            MacHostGas = macHostGas;
        }
    }
}