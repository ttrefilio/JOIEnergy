using System.Collections.Generic;
using JOIEnergy.Domain.Entities;

namespace JOIEnergy.Application.Services
{
    public interface IMeterReadingService
    {
        List<ElectricityReading> GetReadings(string smartMeterId);
        void StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings);
    }
}