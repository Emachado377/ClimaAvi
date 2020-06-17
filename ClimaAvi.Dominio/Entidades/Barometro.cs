using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Dominio.Entidades
{
    public class Barometro 
    {
        [Key]
        public Guid Id { get; set; }
        public Decimal Altitude { get; set; }
        public Decimal Temperatura { get; set; }
        public Decimal PressaoAtmosferica { get; set; }
        public Decimal UmidadeAr { get; set; }                    
        public DateTime LeituraBarometro { get; set; }
        public string MacHostBarometro { get; set; }

        public Barometro()
        {
        }

        public Barometro(Decimal altitude, Decimal temperatura, Decimal pressaoAtmosferica, Decimal umidadeAr, DateTime leituraBarometro, string macHostBarometro)
        {
            Altitude = altitude;
            Temperatura = temperatura;
            PressaoAtmosferica = pressaoAtmosferica;
            UmidadeAr = umidadeAr;
            LeituraBarometro = leituraBarometro;
            MacHostBarometro = macHostBarometro;
        }
    }
}
