using KEMA.Data;
using KEMA.Models.ModelBase;
using KEMA.Models;
using KEMA.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using KEMA.Models.Command;

namespace KEMA.ViewModels.Login
{
    class ModifyUserViewModel : BindableBase
    {
        private ModifyUserViewModel() { }
        public ModifyUserViewModel(string oldUserID, string firstName, string lastName, string emailAddress, string userType)
        {
            this._oldUserID = oldUserID;
            this._firstName = firstName;
            this._lastName = lastName;
            this._emailAddress = emailAddress;
            this._userType = userType;
        }

        private Window _editWindow;
        public Window EditWindow
        {
            get { return _editWindow; }
            set { SetProperty(ref _editWindow, value); }
        }
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _userType;
        private string _oldUserID;
        private string _newUserID;
        private string _oldPassword;
        private string _password;
        private string _confirm;

        public string FirstName
        {
            get
            {
                if (_firstName == null) _firstName = "";
                return _firstName;
            }
            set { SetProperty(ref _firstName, value); }
        }
        public string LastName
        {
            get
            {
                if (_lastName == null) _lastName = "";
                return _lastName;
            }
            set { SetProperty(ref _lastName, value); }
        }
        public string EmailAddress
        {
            get
            {
                if (_emailAddress == null) _emailAddress = "";
                return _emailAddress;
            }
            set { SetProperty(ref _emailAddress, value); }
        }
        public string UserType
        {
            get
            {
                if (_userType == null) _userType = "";
                return _userType;
            }
            set { SetProperty(ref _userType, value); }
        }
        public string UserID
        {
            get
            {
                if (_newUserID == null) _newUserID = _oldUserID;
                return _newUserID;
            }
            set { SetProperty(ref _newUserID, value); }
        }
        public string OldPassword
        {
            get
            {
                if (_oldPassword == null) _oldPassword = "";
                return _oldPassword;
            }
            set { SetProperty(ref _oldPassword, value); }
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
        public string Confirm
        {
            get
            {
                if (_confirm == null) _confirm = "";
                return _confirm;
            }
            set { SetProperty(ref _confirm, value); }
        }

        private List<string> _categoryList;
        public List<string> CategoryList
        {
            get
            {
                if (_categoryList == null)
                {
                    _categoryList = new List<string>();
                    _categoryList.Add("Admin");
                    _categoryList.Add("SuperAdmin");
                }
                return _categoryList;
            }
            set { SetProperty(ref _categoryList, value); }
        }

        private ICommand _modifyUserCommand;
        public ICommand ModifyUserCommand
        {
            get
            {
                if (_modifyUserCommand == null) _modifyUserCommand = new RelayCommand(new Action<object>(ModifyUser));
                return _modifyUserCommand;
            }
            set { SetProperty(ref _modifyUserCommand, value); }
        }
        private void ModifyUser(object parameter)
        {
            try
            {
                var modifyUser = new User()
                {
                    user_name = UserID,
                    password = Password,
                    first_name = FirstName,
                    last_name = LastName,
                    email_address = EmailAddress,
                    user_type = UserType
                };

                if (UserManager.ModifyUser(modifyUser, Confirm))
                {
                    PopupProvider.Info(String.Format("User modified: {0}", _oldUserID), String.Format("Modified user: {0}", UserID));
                    EditWindow?.Close();
                }
                else
                {
                    PopupProvider.Error("Edit user error", "Database error");
                }
            }
            catch (ArgumentException e)
            {
                switch (e.ParamName)
                {
                    case "oldUserID":
                        PopupProvider.Error("Edit user error", "The original username is not found in the database.");
                        break;
                    case "oldPassword":
                        PopupProvider.Error("Edit user error", "The old password is incorrect.");
                        break;
                    case "newUserId":
                        PopupProvider.Error("Edit user error", "The new username is unavailable.");
                        break;
                    case "password":
                        PopupProvider.Error("Edit user error", "Please fill the password.");
                        break;
                    case "confirm":
                        PopupProvider.Error("Edit user error", "Password does not match the confirm password.");
                        break;
                    case "noRecord":
                        PopupProvider.Error("Edit user error", "User record does not exist.");
                        break;
                    default:
                        PopupProvider.Error("Edit user error", "User Login error");
                        break;
                }
            }

            //}
        }
    }
}
