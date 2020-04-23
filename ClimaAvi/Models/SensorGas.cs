using System;

namespace ClimaAvi.Models
{
    public class SensorGas
    {
        public float Methane { get; set; }
        public float Propane { get; set; }
        public float Hydrogen { get; set; }
        public float Smoke { get; set; }
        public DateTime Reading  { get; set; }

        public SensorGas()
        {
        }

        public SensorGas(float methane, float propane, float hydrogen, float smoke, DateTime reading)
        {
            Methane = methane;
            Propane = propane;
            Hydrogen = hydrogen;
            Smoke = smoke;
            Reading = reading;
        }
    }
}