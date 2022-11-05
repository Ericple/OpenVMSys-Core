namespace OpenVMSys_Core.Core.FlightReport
{
    public class FlightReportModel : ModelBase
    {
        private readonly string? Content;
        private readonly string? FlightNum;
        private readonly OpenVMSysConfigurations.FlightTypes? FlightType;
        private readonly string? FlightName;
        private readonly string? FlightDescription;
        private readonly OpenVMSysConfigurations.ReportStatus? ReportStatus;
        private readonly float? FlightTime;
        private readonly float? FuelConsumption;
        private readonly float? LandingRate;
        private readonly float? FlightDistance;
    }
}
