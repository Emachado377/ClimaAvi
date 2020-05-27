using System;

namespace ClimaAvi.Models
{
    public class SensorGas
    {
        public float Metano { get; set; }
        public float Propeno { get; set; }
        public float Hidrogenio { get; set; }
        public float Fumaca { get; set; }
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