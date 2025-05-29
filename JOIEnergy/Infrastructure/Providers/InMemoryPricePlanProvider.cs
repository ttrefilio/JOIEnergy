using System;
using System.Collections.Generic;
using JOIEnergy.Domain;
using JOIEnergy.Domain.Constants;
using JOIEnergy.Domain.Entities;

namespace JOIEnergy.Infrastructure.Providers;

public class InMemoryPricePlanProvider
{
    public static List<PricePlan> GetPricePlans()
    {
        return new List<PricePlan> {
                new PricePlan{
                    PlanName = PricePlanIds.MOST_EVIL_PRICE_PLAN_ID,
                    EnergySupplier = Enums.Supplier.DrEvilsDarkEnergy,
                    UnitRate = 10m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                },
                new PricePlan{
                    PlanName = PricePlanIds.RENEWABLES_PRICE_PLAN_ID,
                    EnergySupplier = Enums.Supplier.TheGreenEco,
                    UnitRate = 2m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                },
                new PricePlan{
                    PlanName = PricePlanIds.STANDARD_PRICE_PLAN_ID,
                    EnergySupplier = Enums.Supplier.PowerForEveryone,
                    UnitRate = 1m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                }
            };
    }
}
