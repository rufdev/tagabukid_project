using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using WpfHelpers;
using WpfHelpers.MenuBar;

namespace $safeprojectname$
{
    [ModuleExport(typeof(MangtasModule))]
    public class MangtasModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IMenuService menuService;
        private readonly DelegateCommand showSamplePlugin;
        [ImportingConstructor]
        public MangtasModule(IRegionManager regionManager, IMenuService menuService)
        {
            _regionManager = regionManager;
            this.menuService = menuService;
            this.showSamplePlugin = new DelegateCommand(ShowSamplePlugin);
        }

        public void Initialize()
        {
            menuService.Add(new MenuItem() { Command = showSamplePlugin, Parent = "New Module", Title = "$safeprojectname$" });
        }

        void ShowSamplePlugin()
        {
            _regionManager.AddToRegion(RegionNames.DocumentRegion, ServiceLocator.Current.GetInstance<SamplePlug>());
        }
    }
}
