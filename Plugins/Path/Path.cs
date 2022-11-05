namespace OpenVMSys_Core.Plugins.Path
{
    public class Path
    {
        public static string Join(string[] paths)
        {
            var result = AppDomain.CurrentDomain.BaseDirectory;
            foreach(var path in paths)
            {
                result += path + "\\";
            }
            return result;
        }
    }
}
