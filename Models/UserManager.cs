using KEMA.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Models
{
    public class UserManager
    {
        public static User _LoggedUser = new User();

        public static List<User> GetUsers()
        {
            var userList = new List<User>();
            using (var context = new KEMADbContext())
            {
                userList = context.Users.ToList();
            }
            return userList;
        }

        public static bool AddUser(User newUser)
        {
            if (string.IsNullOrWhiteSpace(newUser.user_name))
            {
                throw new System.ArgumentException("Wrong username.", "userID");
            }
            else if (string.IsNullOrWhiteSpace(newUser.password))
            {
                throw new System.ArgumentException("Wrong password.", "userID");
            }

            try
            {
                using (var context = new KEMADbContext())
                {
                    var checkUser = context.Users.FirstOrDefault(f => f.user_name == newUser.user_name);
                    if (checkUser != null)
                    {
                        return false;
                    }

                    var user = new User();
                    user.user_name = newUser.user_name;
                    user.password = newUser.password;
                    user.first_name = newUser.first_name;
                    user.last_name = newUser.last_name;
                    user.email_address = newUser.email_address;
                    user.user_type = newUser.user_type;
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public static bool ModifyUser(User modifyUser, string confirm)
        {
            if (!string.IsNullOrWhiteSpace(modifyUser.password) && !string.IsNullOrWhiteSpace(confirm) && (modifyUser.password != confirm))
            {
                throw new System.ArgumentException("Mismatch confirm password.", "confirm");
            }

            try
            {
                using (var context = new KEMADbContext())
                {
                    var user = context.Users.FirstOrDefault(f => f.user_name == modifyUser.user_name);

                    if (user == null)
                    {
                        throw new System.ArgumentException("No user record exist.", "noRecord");
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(modifyUser.password)
                            && !string.IsNullOrWhiteSpace(confirm)
                            && (modifyUser.password == confirm))
                        {
                            user.password = confirm;
                        }

                        user.first_name = modifyUser.first_name;
                        user.last_name = modifyUser.last_name;
                        user.email_address = modifyUser.email_address;
                        user.user_type = modifyUser.user_type;
                        context.Users.Update(user);
                        context.SaveChanges();
                    }
                }
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public static void RemoveUser(string userName)
        {
            if (_LoggedUser.user_name != userName)
            {
                try
                {
                    using (var context = new KEMADbContext())
                    {
                        var user = context.Users.FirstOrDefault(f => f.user_name == userName);
                        if (user != null)
                        {
                            //before deleting make sure to delete all related data.
                            var rs = SiteManager.GetList(user.user_id);
                            if (rs != null)
                            {
                                foreach (var s in rs)
                                {
                                    SiteManager.DeleteSite(s);
                                }
                            }

                            //delete equipments
                            var eqs = EquipmentManager.GetList(user.user_id);
                            if (eqs != null)
                            {
                                foreach (var e in eqs)
                                {
                                    EquipmentManager.DeleteEquipment(e);
                                }
                            }

                            //delete user
                            context.Users.Remove(user);
                            context.SaveChanges();
                        }
                    }
                }
                catch (System.Exception)
                {
                    throw new System.ArgumentException("Remove User.", "DatabaseError.");
                }
            }
            else
            {
                throw new System.ArgumentException("Remove User", "CurrentUser");
            }
        }

        public static bool AuthenticateUser(string username, string password)
        {
            var validUser = false;

            using (var context = new KEMADbContext())
            {
                var user = context.Users.FirstOrDefault(s => s.user_name == username && s.password == password);

                if (user != null)
                {
                    _LoggedUser = user;
                    validUser = true;
                }
            }

            return validUser;
        }

        public static void ClearLoggedUser()
        {
            _LoggedUser = new User();
        }

        public static bool IsEmptyUserDatabase()
        {
            var noUsers = false;
            using (var context = new KEMADbContext())
            {
                var users = context.Users.ToList();
                noUsers = users.Count() == 0 ? true : false;
            }
            return noUsers;
        }
    }
}
