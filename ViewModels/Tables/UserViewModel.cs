using KEMA.Models.Entity;
using KEMA.Models;
using KEMA.Popup;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using KEMA.Models.ModelBase;
using KEMA.ViewModels.Login;
using KEMA.Views.Login;

namespace KEMA.ViewModels
{
    public class UsersViewModel : TableModel<UserEntity>
    {
        public UsersViewModel()
        {
            ItemName = "User";
            TableName = "Users Management";
        }
        protected override void DeleteItem(object parameter)
        {
            try
            {
                string UserID = SelectedItem.user_name;
                UserManager.RemoveUser(UserID);
                PopupProvider.Info("User deleted", String.Format("Username: {0}", UserID));
                RefreshList(parameter);
            }
            catch (ArgumentException e)
            {
                switch (e.ParamName)
                {
                    case "CurrentUser":
                        PopupProvider.Error("Delete User", "Unable to delete seleted user. Currently logged-in.");
                        break;

                    default:
                        PopupProvider.Error("Delete User", "Unable to delete selected user. Database error.");
                        break;
                }
            }
        }

        protected override void EditItem(object parameter)
        {
            ModifyUserViewModel MUVM = new ModifyUserViewModel(SelectedItem.user_name, SelectedItem.first_name, SelectedItem.last_name, SelectedItem.email_address, SelectedItem.user_type);
            ModifyUserView MUV = new ModifyUserView() { DataContext = MUVM };
            if ((UserManager._LoggedUser.user_type == "SuperAdmin") || (UserManager._LoggedUser.user_name == SelectedItem.user_name))
            {
                MUVM.EditWindow = MUV;
                MUV.ShowDialog();
            }

            RefreshList(parameter);
        }

        protected override void NewItem(object parameter)
        {
            CreateUserView CUV = new CreateUserView();
            CUV.ShowDialog();
            RefreshList(parameter);
        }

        protected override void RefreshList(object parameter)
        {
            var users = UserManager.GetUsers();
            var userEntities = new List<UserEntity>();
            foreach (var u in users)
            {
                userEntities.Add(new UserEntity()
                {
                    email_address = u.email_address,
                    first_name = u.first_name,
                    last_name = u.last_name,
                    user_id = u.user_id,
                    password = "*****",
                    user_name = u.user_name,
                    user_type = u.user_type
                });
            }
            List = userEntities;
        }
    }
}
