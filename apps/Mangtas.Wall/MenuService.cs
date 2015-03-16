using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevExpress.Xpf.NavBar;
using Microsoft.Practices.Unity;
using WpfHelpers.MenuBar;

namespace Mangtas.Wall
{
    public class MenuService : IMenuService
    {
        private readonly NavBarControl navbarcontrol;
        //private readonly NavBarGroup navbargroup;
        //private readonly NavBarItem navbaritem;

        [InjectionConstructor]
        public MenuService(Shell shell)
        {
            this.navbarcontrol = shell.NavBarContainer;

        }

        public void Add(MenuItem item)
        {
            //NavBarGroup group = GetParent(item.Parent);
           
            NavBarGroup group = new NavBarGroup();

            group.Header = item.Title;
            group.Name = item.Title;
            //NavBarItem menu = new NavBarItem { Content = item.Title, Command = item.Command, Name = "bbi" + Regex.Replace(item.Title, "[^a-zA-Z0-9]", "") };
            //group.Items.Add(menu);
            navbarcontrol.Groups.Add(group);
          
            
            //group.ItemLinks.Add(new BarButtonItemLink { BarItemName = button.Name });
        }

        //NavBarItem GetParent(string parentName)
        //{
        //    foreach (BarItem item in manager.Items)
        //    {
        //        BarSubItem button = item as BarSubItem;
        //        if (button != null && button.Content.ToString() == parentName)
        //            return button;
        //    }
        //    BarSubItem newParent = new BarSubItem { Content = parentName, Name = "bsi" + Regex.Replace(parentName, "[^a-zA-Z0-9]", "") };
        //    manager.Items.Add(newParent);
        //    bar.ItemLinks.Add(new BarSubItemLink { BarItemName = newParent.Name });
        //    return newParent;
        //}


    }
}
