using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Swap
            //Console.WriteLine("Введите переменную 1");
            //var variable1Str = Console.ReadLine();
            //Int32.TryParse(variable1Str, out var variable1);
            //Console.WriteLine("Введите переменную 2");
            //var variable2Str = Console.ReadLine();
            //Int32.TryParse(variable2Str, out var variable2);
            //Console.WriteLine("Переменные до вызова метода Swap");
            //Console.WriteLine($"Переменная 1 = {variable1}, переменная 2 = {variable2}");
            //Swap(ref variable1, ref variable2);
            //Console.WriteLine("Переменные после вызова метода Swap");
            //Console.WriteLine($"Переменная 1 = {variable1}, переменная 2 = {variable2}");
            #endregion
            #region SquareAndCube
            Console.WriteLine("Введите число");
            var variableStr = Console.ReadLine();
            Double.TryParse(variableStr, out var variable);
            SquareAndCube(variable, out var square, out var cube);
            Console.WriteLine("С использованием out параметров");
            Console.WriteLine($"Квадрат числа {variable} = {square}, куб числа {variable} = {cube}");
            var turple = (square: SquareAndCube(variable).Item1, cube: SquareAndCube(variable).Item2);
            Console.WriteLine("С использованием кортежа");
            Console.WriteLine($"Квадрат числа {variable} = {turple.square}, куб числа {variable} = {turple.cube}");
            #endregion
        }

        static void Swap(ref int variable1, ref int variable2)
        {
            var temp = variable1;
            variable1 = variable2;
            variable2 = temp;
        }

        static void SquareAndCube(double variable, out double square, out double cube)
        {
            square = Math.Pow(variable, 2);
            cube = Math.Pow(variable, 3);
        }

        static (double, double) SquareAndCube(double variable)
        {
            var square = Math.Pow(variable, 2);
            var cube = Math.Pow(variable, 3);
            return (square, cube);
        }
    }
}
