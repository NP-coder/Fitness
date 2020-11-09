using BL.Control;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your name:");
            var name = Console.ReadLine();

            var userController = new UserControl(name);
            var eatingController = new EatControl(userController.CurrentUser);

            if (userController.NewUser)
            {
                Console.WriteLine("Gender:");
                var gender = Console.ReadLine();
                var birth = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birth, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Press E - for eating");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
            {
                var foods =  EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
                
            }
            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Name of a product:");
            var food = Console.ReadLine();
            var calories = ParseDouble("calories");
            var prot = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carb = ParseDouble("carbonats");
            var weight = ParseDouble("weight");

            var product = new Food(food,calories,prot,fats,carb);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birth;
            while (true)
            {
                Console.WriteLine("Birth Day (dd:MM:yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out birth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not corect format");
                }
            }

            return birth;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Input {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Not corect format {name}");
                }
            }
        }
    }
}
