using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.NavBar;
using WpfHelpers.MenuBar;

namespace Mangtas.Main
{
    [Export(typeof(IMenuService))]
    public class MenuService : IMenuService
    {
        private readonly NavBarControl manager;
        //private readonly NavBarGroup navbargroup;
        //private readonly NavBarItem navbaritem;

        [ImportingConstructor]
        public MenuService(Shell shell)
        {
            this.manager = shell.NavBarContainer;

        }

        public void Add(MenuItem item)
        {
            NavBarGroup parent = GetParent(item.Parent);
            NavBarItem button = new NavBarItem { Content = item.Title, Command = item.Command, Name = "bbi" + Regex.Replace(item.Title, "[^a-zA-Z0-9]", "") };
            parent.Items.Add(button);
        }

        NavBarGroup GetParent(string parentName)
        {
            foreach (NavBarGroup item in manager.Groups)
            {
                NavBarGroup button = item as NavBarGroup;
                if (button != null && button.Header.ToString() == parentName)
                    return button;
            }
            NavBarGroup newParent = new NavBarGroup { Header = parentName, Name = "bsi" + Regex.Replace(parentName, "[^a-zA-Z0-9]", "") };
            newParent.IsExpanded = false;
            manager.Groups.Add(newParent);
            return newParent;
        }


    }
}
