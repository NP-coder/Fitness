using BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BL.Control
{
    public class EatControl : Base
    {
        private readonly User user;

        public List<Food> Foods { get; }

        public Eat Eating { get; }

        public EatControl(User user)
        {
            this.user = user;
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eat GetEating()
        {
            return Load<Eat>().FirstOrDefault() ?? new Eat(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Eat>() { Eating });
        }
       
    }
}
