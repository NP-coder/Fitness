using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string  Gender { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age { get; set; }

        public User(string name, string gender, int age, double weight, double height)
        {
            #region exeption
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Неможливе ім'я користувача.", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Неможливий пол.", nameof(gender));
            }

            if(age < 1 || age >= 150)
            {
                throw new ArgumentNullException("Неможлива дата народження.", nameof(age));
            }

            if(weight <= 0)
            {
                throw new ArgumentNullException("Неможлива вага.", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentNullException("Неможливий зріст.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public User() { }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Неможливе ім'я користувача.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
