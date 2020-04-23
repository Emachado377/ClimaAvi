using System;

namespace ClimaAvi.Models
{
    public class Barometro
    {
        public float Altitude { get; set; }
        public float Temperatura { get; set; }
        public float PressaoAtmosferica { get; set; }
        public float UmidadeAr { get; set; }
        public DateTime Leitura { get; set; }

        public Barometro()
        {
        }

        public Barometro(float altitude, float temperatura, float pressaoAtmosferica, float umidadeAr, DateTime leitura)
        {
            Altitude = altitude;
            Temperatura = temperatura;
            PressaoAtmosferica = pressaoAtmosferica;
            UmidadeAr = umidadeAr;
            Leitura = leitura;
        }
    }
}
