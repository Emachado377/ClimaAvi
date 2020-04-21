using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimaAvi.Models
{
    public class Planta
    {
        public int CodigoPlanta { get; set; }
        public string NomePlanta { get; set; }
        public double Temperatura { get; set; }
        public DateTime LeituraTemperatura { get; set; }
        public double UmidadeAr { get; set; }
        public DateTime LeituraUmidadeAr { get; set; }
        public double Gas { get; set; }
        public DateTime LeituraGas { get; set; }

        public Planta()
        {
        }
    }
}