using System;
using System.Collections.Generic;

namespace BL.Model
{
    [Serializable]
    public class User
    {
        #region properties
        public int ID { get; set; }
        public string Name { get; set; }

        public int? GenderId { get; set; }

        public virtual Gender Gender { get; set; }

        public DateTime Birth { get; set; } = DateTime.Now;

        public double Weight { get; set; }

        public double Height { get; set; }

        public virtual ICollection<Eat> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public int Age { get { return DateTime.Now.Year - Birth.Year; } }
        #endregion

        public User(string name, Gender gender, DateTime birth, double weight, double height)
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

            if(birth < DateTime.Parse("01.01.1900") || birth >= DateTime.Now)
            {
                throw new ArgumentNullException("Неможлива дата народження.", nameof(birth));
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
            Birth = birth;
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
