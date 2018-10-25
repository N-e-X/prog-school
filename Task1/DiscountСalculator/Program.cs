using System;
using System.Collections;
using System.Reflection;

namespace DiscountСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите добавить новый продукт? 1 - да, 2 - нет");

            int.TryParse(Console.ReadLine(), out var answer);

            if (answer != 1)
                return;

            CreateProduct();

            Console.ReadLine();
        }

        private static void CreateProduct()
        {
            var product = new Product();

            Console.WriteLine("Введите название продукта");

            while ((product.Name = Console.ReadLine()) == "")
            {
                Console.WriteLine("Введите название продукта");
            }

            Console.WriteLine("Введите стоимость продукта");

            int.TryParse(Console.ReadLine(), out var price);

            while (price <= 0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");

                int.TryParse(Console.ReadLine(), out price);
            }

            product.Price = price;

            // получаем список типов скидок из реестра
            var discountTypeList = DiscountTypeRegister.GetTypeList();

            Console.WriteLine($"Введите тип скидки:");
            for (int i = 0; i < discountTypeList.Count; i++)
                Console.WriteLine($"{i + 1} - {discountTypeList[i]}");

            int.TryParse(Console.ReadLine(), out var answer);
            while (answer-1 < 0 && answer-1 >= discountTypeList.Count)
            {
                Console.WriteLine($"Значение типа скидки должно быть от 1 до {discountTypeList.Count}!");
                int.TryParse(Console.ReadLine(), out answer);
            }

            Console.WriteLine($"Выбрана {discountTypeList[answer - 1]}");

            //получаем конструктор класса выбранного типа скидки
            ConstructorInfo ci = discountTypeList[answer - 1].Type.GetConstructor(new Type[] { });

            //вызываем конструтор
            product.Discount = ci.Invoke(new object[] { }) as Discount;

            Console.WriteLine($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р. {product.GetSellInformation()}");
        }
    }
}
