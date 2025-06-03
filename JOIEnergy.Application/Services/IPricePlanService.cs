using System.Collections.Generic;

namespace JOIEnergy.Application.Services
{
    public interface IPricePlanService
    {
        Dictionary<string, decimal> GetConsumptionCostOfElectricityReadingsForEachPricePlan(string smartMeterId);
        decimal? GetCostOfLastWeeksUsage(string smartMeterId);
    }
}