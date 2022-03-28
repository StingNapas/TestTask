using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите переменную 1");
            var variable1Str = Console.ReadLine();
            Int32.TryParse(variable1Str, out var variable1);
            Console.WriteLine("Введите переменную 2");
            var variable2Str = Console.ReadLine();
            Int32.TryParse(variable2Str, out var variable2);
            Console.WriteLine("Переменные до вызова метода Swap");
            Console.WriteLine($"Переменная 1 = {variable1}, переменная 2 = {variable2}");
            Swap(ref variable1, ref variable2);
            Console.WriteLine("Переменные после вызова метода Swap");
            Console.WriteLine($"Переменная 1 = {variable1}, переменная 2 = {variable2}");
        }

        static void Swap(ref int variable1, ref int variable2)
        {
            var temp = variable1;
            variable1 = variable2;
            variable2 = temp;
        }
    }
}
