using System;

namespace JOIEnergy.Domain.Entities;

public class PeakTimeMultiplier
{
    public DayOfWeek DayOfWeek { get; set; }
    public decimal Multiplier { get; set; }
}
