using Microsoft.AspNetCore.Mvc;

namespace OpenVMSys_Core.Core.FlightReport
{
    [ApiController]
    [Route("api/report")]
    public class FlightReportController : ControllerBase
    {
        private readonly FlightReportService _flightReportService = new();
        [HttpGet]
        public ActionResult<object> Get() 
            => _flightReportService.Get();
        [HttpGet("{identifier}")]
        public ActionResult<object> Get(string identifer) 
            => _flightReportService.Get(identifer);
        [HttpPost]
        public ActionResult Add(
            string content,
            string flightNum,
            int flightTypes,
            string? flightName,
            string? flightDescription,
            int reportStatus,
            float flightTime,
            float fuelConsumption,
            float landingRate,
            float flightDistance)
        {
            try
            {
                _flightReportService.Create(new MongoDB.Bson.BsonDocument
                {
                    {"Content",content},
                    {"FlightNum",flightNum },
                    {"FlightTypes",flightTypes},
                    {"FlightName",flightName},
                    {"FlightTime",flightTime},
                    {"FuelConsumption",fuelConsumption},
                    {"LandingRate",landingRate},
                    {"FlightDistance",flightDistance},
                    {"FlightDescription",flightDescription},
                    {"ReportStatus",reportStatus},
                });
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
