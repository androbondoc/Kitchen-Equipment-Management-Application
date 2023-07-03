using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using KEMA.Models.ModelBase;
using KEMA.Models;
using KEMA.Popup;
using KEMA.Models.Command;
using KEMA.Views.Login;

namespace KEMA.ViewModels.Login
{
    class LoginViewModel : BindableBase
    {
        private string _userID;
        private string _password;
        public Window LoginWindow { get; set; }
        public string UserID
        {
            get
            {
                if (_userID == null) _userID = "";
                return _userID;
            }
            set { SetProperty(ref _userID, value); }
        }
        public string Password
        {
            get
            {
                if (_password == null) _password = "";
                return _password;
            }
            set { SetProperty(ref _password, value); }
        }

        private ICommand _click_LoginCommand;
        public ICommand Click_LoginCommand
        {
            get
            {
                if (_click_LoginCommand == null) _click_LoginCommand = new RelayCommand(new Action<object>(Login));
                return _click_LoginCommand;
            }
            set { SetProperty(ref _click_LoginCommand, value); }
        }

        private void Login(object parameter)
        {

            PasswordBox pwBox = (PasswordBox)parameter;
            Password = pwBox.Password;

            try
            {
                if (UserManager.AuthenticateUser(UserID, Password))
                {
                    PopupProvider.Info(String.Format("Welcome, {0}!", UserID), "You have succesfully logged in.");
                    LoginWindow.Close();
                }
                else
                {
                    PopupProvider.Error("Login error", "Invalid username/password.");
                }
            }
            catch (ArgumentException e)
            {
                PopupProvider.Error("Login error", e.Message);
            }

        }

        private ICommand _click_SetupCommand;
        public ICommand Click_SetupCommand
        {
            get
            {
                if (_click_SetupCommand == null) _click_SetupCommand = new RelayCommand(new Action<object>(Setup));
                return _click_SetupCommand;
            }
            set { SetProperty(ref _click_SetupCommand, value); }
        }

        private void Setup(object parameter)
        {
            CreateUserView CUV = new CreateUserView();
            CUV.ShowDialog();
        }
    }
}
