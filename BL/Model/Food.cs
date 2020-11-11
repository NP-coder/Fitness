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
        #region properties
        public string Name { get; }

        public double Proteines { get;} //belki

        public double Fats { get;} //giri

        public double Carbohydrates { get; } //uglerodi

        public double Calories { get; }

        private double CaloriesOneGram { get { return Calories / 100.0; } }

        private double ProteinesOneGram { get { return Proteines / 100.0; } }

        private double FatsOneGram { get { return Fats / 100.0; } } 

        private double CarbohydratesOneGram { get { return Carbohydrates / 100.0; } }
        #endregion

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
