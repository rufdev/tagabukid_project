using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Docking;
using Microsoft.Practices.Prism.Regions;
using WpfHelpers;

namespace Mangtas.Wall.Adapters
{
    public class DocumentGroupAdapter : RegionAdapterBase<DocumentGroup>
    {
        
        public DocumentGroupAdapter(IRegionBehaviorFactory behaviorFactory) :
            base(behaviorFactory)
        {
        }
        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
        protected override void Adapt(IRegion region, DocumentGroup regionTarget)
        {
            region.Views.CollectionChanged += (s, e) => OnViewsCollectionChanged(region, regionTarget, s, e);
        }
        void OnViewsCollectionChanged(IRegion region, DocumentGroup regionTarget, object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (object view in e.NewItems)
                {
                    DockLayoutManager manager = regionTarget.GetDockLayoutManager();
                    DocumentPanel panel = manager.DockController.AddDocumentPanel(regionTarget);
                    panel.Content = view;
                    var info = view as IPanelInfo;
                    if (info != null)
                        panel.Caption = info.GetPanelCaption();
                    else panel.Caption = "new Page";
                    manager.DockController.Activate(panel);
                }
            }
        }
    }
}
