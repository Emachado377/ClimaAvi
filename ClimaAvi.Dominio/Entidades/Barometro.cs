using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Dominio.Entidades
{
    public class Barometro 
    {
        [Key]
        public Guid Id { get; set; }
        public float Altitude { get; set; }
        public float Temperatura { get; set; }
        public float PressaoAtmosferica { get; set; }
        public float UmidadeAr { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:SS}", ApplyFormatInEditMode = true)]
        public DateTime LeituraBarometro { get; set; }
        public string MacHostBarometro { get; set; }

        public Barometro()
        {
        }

        public Barometro(float altitude, float temperatura, float pressaoAtmosferica, float umidadeAr, DateTime leituraBarometro, string macHostBarometro)
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
