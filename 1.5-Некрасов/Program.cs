using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1._5_Некрасов
{
    class Program
    {

        static char[] StringToCharArray(string userLine)
        {
            userLine = Regex.Replace(userLine, "[^a-zа-я]", "", RegexOptions.IgnoreCase);

            char[] userLineChars = new char[userLine.Length];

            for (int i = 0; i < userLine.Length; i++)
            {
                userLineChars[i] = userLine[i];
            }

            return userLineChars;
        }

        static void OperationWithArray(int[,] userArray)
        {
            if (userArray.GetLength(0) != userArray.GetLength(0))
            {
                Console.WriteLine("Введен неверный массив");
                return;
            }

            for (int i = 0; i < userArray.GetLength(1); i++) {
                var tmp = userArray[i, i];
                userArray[i, i] = userArray[i, userArray.GetLength(0) - 1 - i];
                userArray[i, userArray.GetLength(0) - 1 - i] = tmp;
            }

            printArray(userArray);
        }

        static void printArray(int[,] paramArray)
        {
            for(int i = 0; i < paramArray.GetLength(0); i++) {
                for(int j = 0; j < paramArray.GetLength(1); j++) {
                    Console.Write(paramArray[i,j]);
                }
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            string introduceLine = Console.ReadLine();

            char[] newUserLine = StringToCharArray(introduceLine);


            int[,] matrix = new int[5, 5] { { 2, 1, 1, 1, 3 }, //(ряд, колонки) 
                                            { 1, 2, 1, 3, 1 }, 
                                            { 1, 1, 2, 1, 1 }, 
                                            { 1, 3, 1, 2, 1 }, 
                                            { 3, 1, 1, 1, 2 }};

            OperationWithArray(matrix);

            Console.ReadKey();
        }
    }
}
