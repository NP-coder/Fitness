using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model
{
    [Serializable]
    public class Eat
    {
        public int ID { get; set; }
        public DateTime Moment { get; set; }

        public Dictionary<Food, double> Foods { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

        public Eat() { }
        public Eat(User user)
        {
            User = user;
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
