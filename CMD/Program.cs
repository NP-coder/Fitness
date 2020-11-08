using BL.Control;
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
            Console.ReadLine();
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
