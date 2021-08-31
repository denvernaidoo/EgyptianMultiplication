using EgyptianMultiplication.Core.Models;
using System;

namespace EgyptianMultiplication.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This application will multiply two integer factors (A & B) using the Ancient Egyptian Multiplication Method.");
            var A = ReadFactor("A");            
            var B = ReadFactor("B");

            var egyptianMultiplier = new EgyptianMultiplier();
            var product = egyptianMultiplier.Multiply(A, B);
            Console.WriteLine("Result:");
            Console.WriteLine($"{A} x {B} = {product}");
            Console.ReadKey();
        }

        /// <summary>
        /// Validates and reads and integer factor from the console
        /// </summary>
        /// <param name="factor">Name of factor.</param>
        /// <returns>the integer that the user entered.</returns>
        static int ReadFactor(string factor)
        {            
            var validResponseReceived = false;
            bool isInteger;
            int result = 0;
            while (!validResponseReceived)
            {
                Console.Write($"Enter factor {factor}: ");
                var input = Console.ReadLine();
                isInteger = int.TryParse(input, out result);
                validResponseReceived = isInteger;

                if (!validResponseReceived)
                {
                    Console.WriteLine("Please enter an integer.");
                }                
            }

            return result;
        }
    }
}
