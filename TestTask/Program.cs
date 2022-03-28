using System;
using System.Collections.Generic;
using System.Globalization;

namespace TestTask
{
    public static class ListExtension
    {
        public static void ListShowAllElem(this List<Program.Animal> currentList)
        {
            foreach(var item in currentList)
            {
                Console.WriteLine(item.GetType().Name);
            }
        }
    }
    public class Program
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
            //Console.WriteLine("Введите число");
            //var variableStr = Console.ReadLine();
            //Double.TryParse(variableStr, out var variable);
            //SquareAndCube(variable, out var square, out var cube);
            //Console.WriteLine("С использованием out параметров");
            //Console.WriteLine($"Квадрат числа {variable} = {square}, куб числа {variable} = {cube}");
            //var turple = (square: SquareAndCube(variable).Item1, cube: SquareAndCube(variable).Item2);
            //Console.WriteLine("С использованием кортежа");
            //Console.WriteLine($"Квадрат числа {variable} = {turple.square}, куб числа {variable} = {turple.cube}");
            #endregion
            #region class Animal
            CultureInfo provider = CultureInfo.InvariantCulture;
            var dateBirthday = DateTime.ParseExact("01.04.1993", "dd.MM.yyyy", provider);
            var animal = new Animal();
            animal.Birthday = dateBirthday;
            animal.Name = "Andrew";
            animal.Sex = Sex.Male;
            animal.SayHellow();
            var elephant = new Elephant();
            elephant.Name = "Alex";
            elephant.SayHellow();
            var zebra = new Zebra();
            zebra.Name = "Nastya";
            zebra.SayHellow();
            var giraffe = new Giraffe();
            giraffe.Name = "Gena";
            giraffe.SayHellow();

            List <Animal> animalList = new List<Animal>()
            {
                new Animal(),
                new Zebra(),
                new Giraffe(),
                new Elephant()
            };
            animalList.ListShowAllElem();
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

        public enum Sex
        {
            Male,
            Female
        }

        public class Animal
        {
            public DateTime Birthday { get; set; }
            public string Name { get; set; }
            public Sex Sex { get; set; }
            public int Age
            {
                get
                {
                    var timeSpan = (Birthday - DateTime.Now).Duration();
                    return timeSpan.Days / 366;
                }
            }
            public void ShowProp()
            {
                Console.WriteLine($"Животное {Name}, дата рождения {Birthday.ToString("dd.MM.yyyy")}, возраст {Age}");
            }
            public virtual void SayHellow()
            {
                Console.WriteLine($"Hellow I am {Name}");
            }
            public static Animal operator ++(Animal animal)
            {
                return new Animal { Birthday = animal.Birthday.AddYears(1), Name = animal.Name, Sex = animal.Sex};
            }
        }
        class Elephant : Animal
        {
            public override void SayHellow()
            {
                Console.WriteLine(String.Format("Hellow I am {0} {1}", this.GetType().Name, Name));
            }
        }
        class Zebra : Animal
        {
            public override void SayHellow()
            {
                Console.WriteLine(String.Format("Hellow I am {0} {1}", this.GetType().Name, Name));
            }
        }
        class Giraffe : Animal
        {
            public override void SayHellow()
            {
                Console.WriteLine(String.Format("Hellow I am {0} {1}", this.GetType().Name, Name));
            }
        }

    }
}
