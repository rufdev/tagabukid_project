using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using Mangtas.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: PreApplicationStartMethod(typeof(Initializer), "Initialize")]
[assembly: OwinStartupAttribute(typeof(Mangtas.WebApi.Startup))]
namespace Mangtas.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    public static class Initializer
    {
        public static void Initialize()
        {
            var plugins = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules")).ToList();

            plugins.ForEach(s =>
            {
                var module = new DirectoryInfo(s);
                var di = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, s, "bin"));
                var pluginAssemblyFiles = di.GetFiles(module.Name + ".dll", SearchOption.AllDirectories);
                foreach (var pluginAssemblyFile in pluginAssemblyFiles)
                {
                    var asm = Assembly.LoadFrom(pluginAssemblyFile.FullName);
                    BuildManager.AddReferencedAssembly(asm);
                }
            });


        }
    }
}
