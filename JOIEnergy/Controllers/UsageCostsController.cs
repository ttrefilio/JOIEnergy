
using JOIEnergy.Services;
using Microsoft.AspNetCore.Mvc;

namespace JOIEnergy.Controllers
{
    [Route("api/[controller]")]
    public class UsageCostsController : Controller
    {
        private readonly IPricePlanService pricePlanService;
        public UsageCostsController(IPricePlanService pricePlanService)
        {
            this.pricePlanService = pricePlanService;
        }

        [HttpGet("/{smartMeterId}")]
        public IActionResult GetLastWeekUsageCost(string smartMeterId)
        {
            decimal? lastWeekCost = pricePlanService.GetCostOfLastWeeksUsage(smartMeterId);

            if (lastWeekCost is null)
            {
                return BadRequest(new { error = "No price plan found for the specified smart meter ID" });
            }

            return Ok(new { smartMeterIdd = smartMeterId, lastWeekCosts = lastWeekCost });
        }
    }
}