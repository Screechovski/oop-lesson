using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class chair
    {
        public int chairHeight;
        public int chairLegsLenght;
        public string chairMaterial;
        public chair (int _height, int _legs, string _material)
        {
            chairHeight = _height;
            chairLegsLenght = _legs;
            chairMaterial = _material;
        }


        public void PrintProperties(string param = "")
        {
            if (param == "")
            {
                Console.WriteLine($"chairMaterial: {chairMaterial}");
                Console.WriteLine($"chairLegsLenght: {chairLegsLenght}");
                Console.WriteLine($"chairHeight: {chairHeight}");
            } else
            {
                switch (param)
                {
                    case "chairMaterial":
                        Console.WriteLine($"chairMaterial: {chairMaterial}");
                        break;
                    case "chairLegsLenght":
                        Console.WriteLine($"chairLegsLenght: {chairLegsLenght}");
                        break;
                    case "chairHeight":
                        Console.WriteLine($"chairHeight: {chairHeight}");
                        break;
                    default:
                        Console.WriteLine($"'${param}' was not found in the current class");
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int userChairHeight;
            int userChairLegsLenght;
            string userChairMaterial;

            chair chair1 = new chair(140, 4, "wood");
            chair chair2 = new chair(100, 3, "steel");

            chair1.PrintProperties();
            chair2.PrintProperties("chairMaterial");
            chair2.PrintProperties("asd");


            Console.WriteLine("Введите желаемую высоту стула: ");
            userChairHeight = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во ножек стула: ");
            userChairLegsLenght = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите материал стула: ");
            userChairMaterial = Console.ReadLine();

            chair userChair = new chair(userChairHeight, userChairLegsLenght, userChairMaterial);

            userChair.PrintProperties();
            userChair.PrintProperties("chairMaterial");

            Console.Read();
        }
    }
}
