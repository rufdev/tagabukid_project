using Microsoft.Owin;
using Owin;
using System;
using System.IO;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Hosting;

[assembly: OwinStartupAttribute(typeof(BIPS.Web.Startup))]
namespace BIPS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var pluginFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/modules"));
            //Console.WriteLine(pluginFolder.ToString());
            //var pluginAssemblies = pluginFolder.GetFiles("*.dll", SearchOption.AllDirectories);
            //foreach (var pluginAssemblyFile in pluginAssemblies)
            //{
            //    var asm = Assembly.LoadFrom(pluginAssemblyFile.FullName);
            //    BuildManager.AddReferencedAssembly(asm);
            //}
            ConfigureAuth(app);
        }
    }
}
