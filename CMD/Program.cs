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

            var userController = new UserControler(name);
            var eatingController = new EatControl(userController.CurrentUser);
            var exerciseControler = new ExerciseControl(userController.CurrentUser);

            if (userController.NewUser)
            {
                Console.WriteLine("Gender:");
                var gender = Console.ReadLine();
                var birth = ParseDateTime("Birth");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birth, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Press E - for eating");
            Console.WriteLine("Press A - for exercise");
            var key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);

                    foreach (var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"\t{item.Key} - {item.Value}");
                    }
                    break;

                case ConsoleKey.A:
                    var exe = EnterExercise();
                    exerciseControler.Add(exe.Activity, exe.Begin, exe.End);
                    foreach(var item in exerciseControler.Exercises)
                    {
                        Console.WriteLine($"\t{item.Activity} from {item.Start} to {item.Finish}");
                    }
                    break;
                
            }
            Console.ReadLine();
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Name of a exercise:");
            var name = Console.ReadLine();
            var begin = ParseDateTime("Exercise begin");
            var end = ParseDateTime("Exercise end");
            var energy = ParseDouble("Energy");

            var activity = new Activity(name, energy);

            return (begin, end, activity);
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

        private static DateTime ParseDateTime(string name)
        {
            DateTime birth;
            while (true)
            {
                Console.WriteLine($"{name}  (dd:MM:yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out birth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Not corect format {name}");
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
