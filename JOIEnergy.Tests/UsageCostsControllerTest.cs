using System;
using Xunit;
using Moq;
using JOIEnergy.Services;
using JOIEnergy.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace JOIEnergy.Tests;

public class UsageCostsControllerTest
{
    private static readonly string SMART_METER_ID = "smart-meter-id";
    private static readonly string SMART_METER_NO_PLAN_ID = "smart-meter-no-plan-id";

    [Fact]
    public void GivenSmartMeterWithPricePlan_WhenGettingLastWeekUsageCost_ThenOkResultWithCostIsReturned()
    {
        // Arrange
        decimal expectedCost = 42.5m;
        var pricePlanService = new Mock<IPricePlanService>();
        pricePlanService.Setup(p => p.GetCostOfLastWeeksUsage(SMART_METER_ID)).Returns(expectedCost);

        var controller = new UsageCostsController(pricePlanService.Object);

        // Act
        var result = controller.GetLastWeekUsageCost(SMART_METER_ID);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        dynamic returnValue = okResult.Value;
        Assert.NotNull(returnValue);
        Assert.Equal(SMART_METER_ID, (string)returnValue.GetType().GetProperty("smartMeterId").GetValue(returnValue, null));
        Assert.Equal(expectedCost, (decimal)returnValue.GetType().GetProperty("lastWeekCost").GetValue(returnValue, null));
    }

    [Fact]
    public void GivenSmartMeterWithoutPricePlan_WhenGettingLastWeekUsageCost_ThenBadRequestIsReturned()
    {
        // Arrange
        var pricePlanService = new Mock<IPricePlanService>();
        pricePlanService.Setup(p => p.GetCostOfLastWeeksUsage(SMART_METER_NO_PLAN_ID)).Returns((decimal?)null);

        var controller = new UsageCostsController(pricePlanService.Object);

        // Act
        var result = controller.GetLastWeekUsageCost(SMART_METER_NO_PLAN_ID);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        dynamic returnValue = badRequestResult.Value;
        Assert.Contains("No price plan found", (string)returnValue.GetType().GetProperty("error").GetValue(returnValue, null));
    }

}
