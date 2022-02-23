using System;

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
            Name = name;
            Gender = gender;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public User() { }

        public User(string name)
        {

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
