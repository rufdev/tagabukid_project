using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mangtas.Module.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using WpfHelpers;

namespace Mangtas.Module
{
    public class MangtasModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MangtasModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.DocumentRegion, typeof(Views.SamplePlug));
            //_regionManager.AddToRegion(RegionNames.DocumentRegion, ServiceLocator.Current.GetInstance<SamplePlug>());
        }
        

    }
}
