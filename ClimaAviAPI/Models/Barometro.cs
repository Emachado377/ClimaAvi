using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimaAviAPI.Models
{
    public class Barometro
    {
        public Guid Id { get; set; }
        public float Altitude { get; set; }
        public float Temperatura { get; set; }
        public float PressaoAtmosferica { get; set; }
        public float UmidadeAr { get; set; }
        public DateTime LeituraGas { get; set; }
        public string MacHost { get; set; }


        //public Barometro()
        //{

        //}

        //public Barometro(Guid id, float altitude, float temperatura, float pressaoAtmosferica, float umidadeAr, DateTime leituraBarometro, string macHost)
        //{
        //    Id = id;
        //    Altitude = altitude;
        //    Temperatura = temperatura;
        //    PressaoAtmosferica = pressaoAtmosferica;
        //    UmidadeAr = umidadeAr;
        //    LeituraBarometro = leituraBarometro;
        //    MacHost = macHost;
        //}
    }
}