﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace Mangtas.Main
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export]
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
        }

        private void RibbonControl_OnBackstageClosed(object sender, EventArgs e)
        {
            //check if naka login if wala
            this.BackstageViewControl.IsOpen = true;
            MessageBox.Show("Please login");
        }
    }
}
