using OpenVMSys_Core.Plugins;
using System.Reflection;

OpenVMSysPluginCore openVMSysPluginCore = new();
var pluginList = openVMSysPluginCore.LoadAllPlugins();
foreach (var plugin in pluginList)
{
    Type pluginType = plugin.GetType();
    Console.WriteLine("Loading {0}...", pluginType.Name);
    MethodInfo OnServiceStart = pluginType.GetMethod("OnServiceStart");
    object returnValue = OnServiceStart.Invoke(plugin, null);
    Console.WriteLine(returnValue.ToString());
}
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();