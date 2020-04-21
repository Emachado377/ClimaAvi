using System;

namespace ClimaAvi.Models
{
    public class Barometro
    {
        public double Altitude { get; set; }
        public double Temperatura { get; set; }
        public double PressaoAtmosferica { get; set; }
        public double UmidadeAr { get; set; }
        public DateTime Leitura { get; set; }

        public Barometro()
        {
        }

        public Barometro(double altitude, double temperatura, double pressaoAtmosferica, double umidadeAr, DateTime leitura)
        {
            Altitude = altitude;
            Temperatura = temperatura;
            PressaoAtmosferica = pressaoAtmosferica;
            UmidadeAr = umidadeAr;
            Leitura = leitura;
        }
    }
}
