using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Mangtas.Module.Admin.ViewModels
{
    [Export(typeof(LoginViewModel))]
    public class LoginViewModel : BindableBase
    {
       
        private readonly ICommand _signInCommand;

        [ImportingConstructor]
        public LoginViewModel()
        {
            this._signInCommand = new DelegateCommand(this.SignIn);
        }

        public ICommand SignInCommand { get { return this._signInCommand; } }

        private void SignIn()
        {
            //call webservice to login
            MessageBox.Show("HALAKA LOGIN");
        }


    }

}
