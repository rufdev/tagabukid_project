using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.NavBar;
using Microsoft.Practices.Prism.Regions;
using WpfHelpers;

namespace Mangtas.Wall.Adapters
{
    public class NavBarControlAdapter : RegionAdapterBase<NavBarControl>
    {

        public NavBarControlAdapter(IRegionBehaviorFactory behaviorFactory)
            : base(behaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, NavBarControl regionTarget)
        {
            region.Views.CollectionChanged += (d, e) =>
            {
                foreach (NavBarGroup gr in regionTarget.Groups)
                {
                    if (gr.Items.Count > 0 && gr.Items[0] is INavBarItemView)
                        gr.Items.Clear();
                }
                regionTarget.Groups.Clear();

                foreach (object view in region.Views)
                {
                    if (view is INavBarGroupView)
                    {
                        regionTarget.Groups.Add((NavBarGroup) view);
                    }

                }
                foreach (object view in region.Views)
                {
                    if (view is INavBarItemView)
                    {
                        NavBarGroup gr = FindGroupByName(regionTarget, ((INavBarItemView) view).GroupName);
                        if (gr != null) gr.Items.Add((NavBarItem) view);
                    }
                }
            };
        }

        private NavBarGroup FindGroupByName(NavBarControl c, string name)
        {
            foreach (INavBarGroupView gr in c.Groups)
                if (gr.GroupName == name)
                    return (NavBarGroup) gr;
            return null;
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }

}
