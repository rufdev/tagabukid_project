using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.NavBar;

namespace Mangtas.Wall
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            //var navbarcontrol = this.NavBarContainer;
            //NavBarGroup group = new NavBarGroup();

            //group.Header = "TEST";
            ////NavBarItem menu = new NavBarItem { Content = item.Title, Command = item.Command, Name = "bbi" + Regex.Replace(item.Title, "[^a-zA-Z0-9]", "") };
            ////group.Items.Add(menu);
            //navbarcontrol.Groups.Add(group);
        }
    }
}
