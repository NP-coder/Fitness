namespace BL.Model
{
    public class Food
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Proteines { get; set; } 

        public double Fats { get; set; } 

        public double Carbohydrates { get; set; }

        public double Calories { get; set; }

        public Food() { }

        public Food(string name, double calories, double prot, double fats, double carb)
        {
            Name = name;
            Calories = calories ;
            Proteines = prot ;
            Fats = fats ;
            Carbohydrates = carb;
        }

        public override string ToString()
        {
            return Name;
        }   
    }
}
