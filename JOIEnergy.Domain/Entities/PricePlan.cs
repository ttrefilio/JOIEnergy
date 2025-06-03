using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Enums;

namespace JOIEnergy.Domain.Entities
{
    public class PricePlan
    {
        public string PlanName { get; set; }
        public Supplier EnergySupplier { get; set; }
        public decimal UnitRate { get; set; }
        public IList<PeakTimeMultiplier> PeakTimeMultiplier { get; set;}

        public decimal GetPrice(DateTime datetime) {
            var multiplier = PeakTimeMultiplier.FirstOrDefault(m => m.DayOfWeek == datetime.DayOfWeek);

            if (multiplier?.Multiplier != null) {
                return multiplier.Multiplier * UnitRate;
            } else {
                return UnitRate;
            }
        }
    }    
}
