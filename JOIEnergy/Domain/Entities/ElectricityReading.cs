using System;
namespace JOIEnergy.Domain.Entities
{
    public class ElectricityReading
    {
        public DateTime Time { get; set; }
        public Decimal Reading { get; set; }
    }
}
