using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimaAviAPI.Models
{
    public class SensorGas
    {
        public Guid Id { get; set; }
        public float Metano { get; set; }
        public float Propeno { get; set; }
        public float Hidrogenio { get; set; }
        public float Fumaca { get; set; }
        public DateTime LeituraGas { get; set; }
        public string MacHost { get; set; }
       

    }
}