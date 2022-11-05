namespace OpenVMSys_Core
{
    public class OpenVMSysConfigurations
    {
        //Site and database configuration
        public static string SiteName = "OpenVMSys";
        public static string SiteUrl = "https://localhost/";
        public static string DatabaseUrl = "mongodb://127.0.0.1:27017/";

        //=================================================================
        // BELOW ARE PROGRAM SETTINGS, DO NOT EDIT UNLESS YOU ARE ASKED TO!
        //=================================================================
        //=================================================================
        // BELOW ARE PROGRAM SETTINGS, DO NOT EDIT UNLESS YOU ARE ASKED TO!
        //=================================================================
        //=====================
        // YOU HAVE BEEN WARNED
        //=====================
        public static readonly Version version = new(1, 3, 16);
        //SecurityKeyModel Permission Level
        public enum SecurityPermission
        {
            Low=0,
            Mid=50,
            High=100,
            Top=999
        }
        //Flight Status
        public enum FlightStatus
        {
            Prepare,
            Push,
            Taxi,
            Takeoff,
            Climb,
            Cruise,
            Descend,
            Approach,
            Landed
        }
        //Flight Types
        public enum FlightTypes
        {
            Passenger,
            Cargo,
            
        }
        //Report Status
        public enum ReportStatus
        {
            Approved,
            Decliend
        }
    }
}
