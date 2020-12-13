
namespace BL.Model
{
    public class Activity
    {
        public int ID { get; set; }
        public string Name { get; set; }
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
