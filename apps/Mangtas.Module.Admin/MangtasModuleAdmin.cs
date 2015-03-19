using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Editors.Helpers;
using Mangtas.Module.Admin.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using WpfHelpers;
using WpfHelpers.MenuBar;

namespace Mangtas.Module.Admin
{
    [ModuleExport(typeof(MangtasModuleAdmin))]
    public class MangtasModuleAdmin : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IMenuService menuService;
        private readonly DelegateCommand showSamplePlugin;
        [ImportingConstructor]
        public MangtasModuleAdmin(IRegionManager regionManager, IMenuService menuService)
        {
            _regionManager = regionManager;
            this.menuService = menuService;
            this.showSamplePlugin = new DelegateCommand(ShowSamplePlugin);
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.BackStageNav, typeof(LoginManager));
            _regionManager.RegisterViewWithRegion(RegionNames.BackStageNav, typeof(Logout));
            _regionManager.RegisterViewWithRegion("LoginFormRegion", typeof(LoginForm));

            //menuService.Add(new MenuItem() { Command = showSamplePlugin, Parent = "New Module", Title = "Sample link 1" });
        }

        void ShowSamplePlugin()
        {
            //_regionManager.AddToRegion(RegionNames.DocumentRegion, ServiceLocator.Current.GetInstance<SamplePlug>());
        }
    }
}
