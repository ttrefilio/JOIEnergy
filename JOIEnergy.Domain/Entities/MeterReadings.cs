using System;
using System.Collections.Generic;
using JOIEnergy.Domain.Entities;

namespace JOIEnergy.Domain.Entities
{
    public class MeterReadings
    {
        public string SmartMeterId { get; set; }
        public List<ElectricityReading> ElectricityReadings { get; set; }
    }
}
