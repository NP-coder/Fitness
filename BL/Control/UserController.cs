using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Control
{
    public class UserControler : Base
    {
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool NewUser { get; } = false;

        public UserControler(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Неможливе ім'я користувача", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.FirstOrDefault(u => u.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                NewUser = true;
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
            Save(Users);
        }

        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }
    }

}
