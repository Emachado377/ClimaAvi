using System;

namespace ClimaAvi.Models
{
    public class SensorGas
    {
        public double Metano { get; set; }
        public double Propano { get; set; }
        public double Hidrogenio { get; set; }
        public DateTime Leitura { get; set; }

        public SensorGas()
        {
        }

        public SensorGas(double metano, double propano, double hidrogenio, DateTime leitura)
        {
            Metano = metano;
            Propano = propano;
            Hidrogenio = hidrogenio;
            Leitura = leitura;
        }
    }
}