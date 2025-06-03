using System;
using System.Collections.Generic;
using JOIEnergy.Domain.Constants;

namespace JOIEnergy.Infrastructure.Providers;

public static class InMemorySmartMeterToPricePlanAccountsProvider
{
    public static Dictionary<string, string> GetSmartMeterToPricePlanAccounts()
    {

        return new Dictionary<string, string>()
            {
                {"smart-meter-0", PricePlanIds.MOST_EVIL_PRICE_PLAN_ID },
                { "smart-meter-1", PricePlanIds.RENEWABLES_PRICE_PLAN_ID },
                { "smart-meter-2", PricePlanIds.MOST_EVIL_PRICE_PLAN_ID },
                { "smart-meter-3", PricePlanIds.STANDARD_PRICE_PLAN_ID },
                { "smart-meter-4", PricePlanIds.RENEWABLES_PRICE_PLAN_ID }
            };

    }
}
