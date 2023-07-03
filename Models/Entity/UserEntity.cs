using KEMA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Models.Entity
{
    public class UserEntity : User
    {
        public UserEntity() { }
        public UserEntity(string user, string pw) { user_name = user; password = pw; }
    }
}
