using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Reflection;
using OpenVMSys_Console.Module;

namespace OpenVMSys_Core.Plugins.PluginIntergrator
{
    [ApiController]
    [Route("api")]
    public class PluginController : ControllerBase
    {
        private PluginManager pluginManager = new();
        private static readonly OpenVMSysPluginCore openVMSysPluginService = new();
        private static readonly ArrayList pluginList = openVMSysPluginService.LoadAllPlugins();
        [HttpGet("{apiName}")]
        public ActionResult<object> Get(string apiName, string data)
        {
            foreach(var plugin in pluginList)
            {
                if (apiName == plugin.GetType().Name && pluginManager.IsEnabled(apiName))
                {
                    MethodInfo OnGet=plugin.GetType().GetMethod("OnGet");
                    object returnValue=OnGet.Invoke(plugin, new object[] {data});
                    return returnValue;
                }
            }
            return BadRequest();
        }
    }
}
