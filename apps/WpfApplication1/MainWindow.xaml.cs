using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            //var test = new ArrayList() { "TEST", "TEST2", "TEST3" };

            //var test2 = new Dictionary<int, string>();
            //test2.Add(1,"TEST");
            //test2.Add(2, "TEST2");
            //test2.Add(3, "TEST3");
            //test2.Add(4, "TEST4");

            ////this.cmbTest.Items.Add("TEST");
            ////this.cmbTest.Items.Add("TEST1");
            ////this.cmbTest.Items.Add("TEST");
            //foreach (var t in test2)
            //{
            //    this.cmbTest.Items.Add(t);
            //}
            var offices = new List<Office>()
            {
                new Office()
                {
                    Id = 1,
                    Name = "PICTD"
                },
                new Office()
                {
                    Id = 2,
                    Name = "PHRMO"
                }
            };

            var personnels = new List<Personnel>()
            {
                new Personnel()
                {
                    Id = 1,
                    FirstName = "Dabid",
                    LastName = "Cabatingan",
                    OfficeId = 1

                },
                new Personnel()
                {
                    Id = 1,
                    FirstName = "Rufy",
                    LastName = "Aguilar",
                    OfficeId = 2

                }
            };

            
            foreach (var t in offices)
            {
                this.cmbOffice.Items.Add(t);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //this.cmbTest.SelectedItem.ToString().ToDictionary();
            //this.textbox1.Text = ;
        }

       
    }
}
