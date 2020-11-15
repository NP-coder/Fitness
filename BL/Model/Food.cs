using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model
{
    [Serializable]
    public class Food
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public double Proteines { get; set; } //belki

        public double Fats { get; set; } //giri

        public double Carbohydrates { get; set; } //uglerodi

        public double Calories { get; set; }
        public virtual ICollection<Eat> Eatings { get; set; }

        public Food() { }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double calories, double prot, double fats, double carb)
        {
            Name = name;
            Calories = calories / 100.0;
            Proteines = prot / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carb / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }   
    }
}
