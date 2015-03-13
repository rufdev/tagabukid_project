using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

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
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.SamplePlug));
        }
        

    }
}
