using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
            //animal.SayHellow();
            var elephant = new Elephant();
            elephant.Birthday = dateBirthday.AddYears(10);
            elephant.Name = "Alex";
            //elephant.SayHellow();
            var zebra = new Zebra();
            zebra.Birthday = dateBirthday.AddYears(20);
            zebra.Name = "Nastya";
            //zebra.SayHellow();
            var giraffe = new Giraffe();
            giraffe.Birthday = dateBirthday.AddYears(27);
            giraffe.Name = "Gena";
            //giraffe.SayHellow();

            List <Animal> animalList = new List<Animal>()
            {
                animal,
                elephant,
                zebra,
                giraffe
            };
            Console.WriteLine("Полный список животных");
            animalList.ListShowAllElem();
            var linqTask1 = AgeLess2_1(animalList);
            Console.WriteLine("Возраст меньше 2 методом расширений");
            linqTask1.ListShowAllElem();
            linqTask1 = AgeLess2_2(animalList);
            Console.WriteLine("Возраст меньше 2 запросом");
            linqTask1.ListShowAllElem();

            var linqTask2 = FilterByZebra_1(animalList);
            Console.WriteLine("Только Зебры методом расширений");
            linqTask2.ListShowAllElem();
            linqTask2 = FilterByZebra_2(animalList);
            Console.WriteLine("Только Зебры запросом");
            linqTask2.ListShowAllElem();

            var linqTask3 = SumAge_1(animalList);
            Console.WriteLine($"Сумма возрастов методом расширений = {linqTask3}");
            linqTask3 = SumAge_2(animalList);
            Console.WriteLine($"Сумма возрастов запросом = {linqTask3}");
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

        // -------------------- LINQ -----------------------------
        public static List<Animal> AgeLess2_1(List<Animal> inputList)
        {
            return inputList.Where(a => a.Age < 2).ToList();
        }
        public static List<Animal> AgeLess2_2(List<Animal> inputList)
        {
            var result = from item in inputList
                         where item.Age < 2
                         select item;
            return result.ToList();
        }

        public static List<Animal> FilterByZebra_1(List<Animal> inputList)
        {
            return inputList.Where(a => a.GetType().Equals(typeof(Zebra))).ToList();
        }
        public static List<Animal> FilterByZebra_2(List<Animal> inputList)
        {
            var result = from item in inputList
                         where item.GetType().Equals(typeof(Zebra))
                         select item;
            return result.ToList();
        }

        public static int SumAge_1(List<Animal> inputList)
        {
            return inputList.Sum(a => a.Age);
        }
        public static int SumAge_2(List<Animal> inputList)
        {
            var result = from item in inputList
                         select item.Age;
            return result.Sum();
        }
    }
}
