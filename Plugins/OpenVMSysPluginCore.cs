using System.Reflection;
using System.Collections;
using OpenVMSys_Console.Module;

namespace OpenVMSys_Core.Plugins
{
    public class OpenVMSysPluginCore
    {

        public ArrayList LoadAllPlugins()
        {
            ArrayList Plugins = new();
            try
            {
                string[] plugins = Directory.GetFiles(Path.Path.Join(new string[]
            {
                "plugins"
            }));

                foreach (string fileName in plugins)
                {
                    if (fileName.ToUpper().EndsWith(".DLL"))
                    {
                        try
                        {
                            Assembly loadPlugin = Assembly.LoadFrom(fileName);
                            Type[] types = loadPlugin.GetTypes();
                            foreach (Type type in types)
                            {
                                if (type.GetInterface("IOpenVMSysPlugin") != null)
                                {
                                    Plugins.Add(loadPlugin.CreateInstance(type.FullName));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Plugins load error: \n{0}", ex.Message);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Notice: There's No Plugin in your /plugin Directory");
            }
            return Plugins;
        }
    }
}
