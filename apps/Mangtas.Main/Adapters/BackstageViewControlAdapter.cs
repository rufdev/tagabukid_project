using System.ComponentModel.Composition;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Ribbon;
using Microsoft.Practices.Prism.Regions;
using WpfHelpers;
using System.Collections.Specialized;

namespace Mangtas.Main.Adapters
{
    [Export(typeof(BackstageViewControlAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class BackstageViewControlAdapter : RegionAdapterBase<BackstageViewControl>
    {
        [ImportingConstructor]
        public BackstageViewControlAdapter(IRegionBehaviorFactory behaviorFactory)
            : base(behaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, BackstageViewControl regionTarget)
        {

            region.Views.CollectionChanged += (d, e) =>
            {

                if (regionTarget.Items.Count > 0)
                    regionTarget.Items.Clear();

                foreach (var view in region.Views)
                {
                    if (view is BackstageTabItem)
                    {
                        regionTarget.Items.Add((BackstageTabItem)view);
                    }
                    else if (view is BackstageButtonItem)
                    {
                        regionTarget.Items.Add((BackstageButtonItem)view);
                    }
                        
                }
                var close = new BackstageButtonItem();
                close.Content = "Close";
                regionTarget.Items.Add(close);
                
            };
        }


        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }

}
