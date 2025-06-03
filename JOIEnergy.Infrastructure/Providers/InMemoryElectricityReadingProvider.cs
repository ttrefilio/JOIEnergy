using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Entities;
using JOIEnergy.Infrastructure.Generator;

namespace JOIEnergy.Infrastructure.Providers;

public static class InMemoryElectricityReadingProvider
{
    public static Dictionary<string, List<ElectricityReading>> GenerateMeterElectricityReadings()
    {
        var readings = new Dictionary<string, List<ElectricityReading>>();
        var generator = new ElectricityReadingGenerator();
        var smartMeterIds = InMemorySmartMeterToPricePlanAccountsProvider.GetSmartMeterToPricePlanAccounts().Select(mtpp => mtpp.Key);

        foreach (var smartMeterId in smartMeterIds)
        {
            readings.Add(smartMeterId, generator.Generate(20));
        }
        return readings;
    }

}
