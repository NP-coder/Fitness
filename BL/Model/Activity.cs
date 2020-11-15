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
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public double CaloriesPerMinute { get; set; }
        public Activity() { }
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
