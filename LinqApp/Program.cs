using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    public enum SexEnum
    {
        Male,
        Female
    }

    public class Person
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public SexEnum Sex { get; set; }
        public int Balance { get; set; }

        public Person(string name, uint age, SexEnum sex, int balance)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Balance = balance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
            {
                new Person("Иван", 31, SexEnum.Male, 400),
                new Person("Марья", 31, SexEnum.Female, 1500),
                new Person("Женя", 24, SexEnum.Male, 21000),
                new Person("Даша", 22, SexEnum.Female, 570),
                new Person("Леша", 25, SexEnum.Male, 14758),
                new Person("Соня", 27, SexEnum.Female, 4792)
            };

            // Поиск самого старого человека через сортировку
            //var oldestPerson = people.
            //    OrderByDescending(x => x.Age).
            //    FirstOrDefault();

            // Оптимизированный поиск самого старого
            var oldestPerson = people.FirstOrDefault(x => x.Age == people.Max(a => a.Age));

            Console.WriteLine($"{oldestPerson?.Name} самый старый");

            // Поиск самого богатого
            var reachestPerson = people.FirstOrDefault(x => x.Balance == people.Max(b => b.Balance));

            Console.WriteLine($"{reachestPerson?.Name} самый богатый");

            // Нахождение самых старых, а затем самого богатого из них

            // Через сортировки:
            //var oldReachPerson = people.
            //    OrderByDescending(x => x.Age).
            //    ThenByDescending(x => x.Balance).FirstOrDefault();

            // Используя 2 переменные:
            //var oldPeople = people.Where(x => x.Age == people.Max(a => a.Age)); // Остаётся список только самых старых
            //var oldReachPerson = oldPeople.FirstOrDefault(x => x.Balance == oldPeople.Max(b => b.Balance)); // Узнаём, кто из них самый богатый

            // Используя 1 переменную:
            var oldReachPerson = people.FirstOrDefault(x => x.Balance == people.Where(a => a.Age == people.Max(y => y.Age)).Max(b => b.Balance));
            
            Console.WriteLine($"{oldReachPerson?.Name} самый старый и богатый");


            // Количество человек, у которых на счету больше 4000
            var quantityReachPeople = people.Count(x => x.Balance > 4000);

            Console.WriteLine($"У {quantityReachPeople} человек(а) на счету больше 4000");
            
            // Сортировка по возрасту по возрастанию
            var sortedByAge = people.OrderBy(x => x.Age);
            // Сортировка по полу по возрастанию
            var sortedBySex = people.OrderBy(x => x.Sex);
            // Сортировка по деньгам по возрастанию
            var sortedByBalance = people.OrderBy(x => x.Balance);
            // Всё вместе
            var sorted = people.OrderBy(x => x.Age).ThenBy(x => x.Sex).ThenBy(x => x.Balance);

            Console.ReadKey();
        }
    }
}
