using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Dominio.Entidades
{
    public class SensorGas
    {
        [Key]
        public Guid Id { get; set; }
        public Decimal Metano { get; set; }
        public Decimal Propeno { get; set; }
        public Decimal Hidrogenio { get; set; }
        public Decimal Fumaca { get; set; }        
        public DateTime LeituraGas { get; set; }
        public string MacHostGas { get; set; }

        public SensorGas()
        {
        }

        public SensorGas(Decimal metano, Decimal propeno, Decimal hidrogenio, Decimal fumaca, DateTime leituraGas, string macHostGas)
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