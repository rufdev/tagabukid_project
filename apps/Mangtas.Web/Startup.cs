using Mangtas.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Mangtas.Web
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
