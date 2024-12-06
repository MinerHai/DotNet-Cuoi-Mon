using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanChuyen_App.models
{
    public class Users
    {
        public Users(int id, string? userName, string? password, string? role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Role = role;
        }
        public Users(int id, string? userName , string? role)
        {
            Id = id;
            UserName = userName;
            Role = role;
        }

        public int Id { set; get; }
        public string? UserName { set; get; }
        public string? Password { set; get; }
        public string? Role { set; get; }
    }
}
