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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mangtas.Module.Admin.ViewModels;

namespace Mangtas.Module.Admin.Views
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
    public partial class LoginForm : ContentControl
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        [Import]
        public LoginViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
