﻿using System.Collections.Generic;
using JOIEnergy.Domain;
using JOIEnergy.Domain.Entities;

namespace JOIEnergy.Services
{
    public interface IMeterReadingService
    {
        List<ElectricityReading> GetReadings(string smartMeterId);
        void StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings);
    }
}