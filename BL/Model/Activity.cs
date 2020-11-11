using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }

        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesperminute)
        {
            Name = name;
            CaloriesPerMinute = caloriesperminute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
