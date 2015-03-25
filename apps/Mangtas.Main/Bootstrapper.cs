using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Ribbon;
using Mangtas.Main.Adapters;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using WpfHelpers;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.NavBar;

namespace Mangtas.Main
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(RegionNames).Assembly));
            //AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MangtasModuleAdmin).Assembly));
        }
        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Shell)Shell;
            App.Current.MainWindow.Show();
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            if (mappings != null)
            {
                //mappings.RegisterMapping(typeof(DockLayoutManager), ServiceLocator.Current.GetInstance<DockManagerAdapter>());
                mappings.RegisterMapping(typeof(DocumentGroup), Container.GetExportedValue<DocumentGroupAdapter>());
                mappings.RegisterMapping(typeof(NavBarControl), Container.GetExportedValue<NavBarControlAdapter>());
                mappings.RegisterMapping(typeof(BackstageViewControl), Container.GetExportedValue<BackstageViewControlAdapter>());


            }
            return mappings;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            string modulesdir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
            return new DirectoryModuleCatalog() { ModulePath = Path.Combine(modulesdir, "modules") };
        }
    }
}
