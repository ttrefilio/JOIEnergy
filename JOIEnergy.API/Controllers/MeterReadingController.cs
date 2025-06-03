using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using JOIEnergy.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JOIEnergy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeterReadingController : Controller
    {
        private readonly IMeterReadingService _meterReadingService;

        public MeterReadingController(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] MeterReadings meterReadings)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            _meterReadingService.StoreReadings(meterReadings.SmartMeterId, meterReadings.ElectricityReadings);
            return Created(string.Empty, new { details = "aaa" });
        }

        private bool IsMeterReadingsValid(MeterReadings meterReadings)
        {
            string smartMeterId = meterReadings.SmartMeterId;
            List<ElectricityReading> electricityReadings = meterReadings.ElectricityReadings;
            return smartMeterId != null && smartMeterId.Any()
                    && electricityReadings != null && electricityReadings.Any();
        }

        [HttpGet("{smartMeterId}")]
        public ObjectResult GetReading(string smartMeterId)
        {
            return new OkObjectResult(_meterReadingService.GetReadings(smartMeterId));
        }
    }
}
