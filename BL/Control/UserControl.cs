using BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BL.Control
{
    public class UserControl
    {
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool NewUser { get; } = false;

        public UserControl(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Неможливе ім'я користувача", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                NewUser = true;
                Save();
            }
        }

        public void SetNewUserData(string gendername, DateTime birth, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(gendername);
            CurrentUser.Birth = birth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        public void Save()
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, Users);
            }
        }

        private List<User> GetUsersData()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if( formater.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
    }

}
