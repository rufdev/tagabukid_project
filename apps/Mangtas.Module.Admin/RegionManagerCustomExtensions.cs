using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Mangtas.Module.Admin
{
    public static class RegionManagerCustomExtensions
    {
        public static IRegionManager RegisterViewWithRegionInIndex(this IRegionManager regionManager, string regionName, Type viewType, int index)
        {
            IRegion mainRegion = regionManager.Regions[regionName];
            int viewsAmount = mainRegion.Views.Count();
            if (index > viewsAmount)
            {
                throw new IndexOutOfRangeException("Tried to add a view to a region that does not have enough views.");
            }

            if (index < 0)
            {
                throw new IndexOutOfRangeException("Tried to add a view in a negative index.");
            }

            object activeView = null;

            if (mainRegion.ActiveViews.Count() == 1)
            {
                activeView = mainRegion.ActiveViews.First();
            }

            var regionViewRegistry = ServiceLocator.Current.GetInstance<IRegionViewRegistry>();

            // Save reference to each view existing in the RegionManager after the index to insert.
            List<object> views = mainRegion.Views.SkipWhile((view, removeFrom) => removeFrom < index).ToList();

            //Remove elements from region that are after index to insert.
            for (int i = 0; i < views.Count; i++)
            {
                mainRegion.Remove(mainRegion.Views.ElementAt(index));
            }

            //Register view in index to insert.
            regionViewRegistry.RegisterViewWithRegion(regionName, viewType);

            // Adding previously removed views
            views.ForEach(view => mainRegion.Add(view));

            if (activeView != null)
            {
                mainRegion.Activate(activeView);
            }

            return regionManager;
        }
    }
}
