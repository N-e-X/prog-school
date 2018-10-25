using System;

namespace DiscountСalculator.DiscountTypes
{
    public class CostDiscount : Discount
    {
        public override int CalculateDiscountPrice(int price)
        {
            Console.WriteLine("Введите значение скидки на товар (в руб.)");
            int.TryParse(Console.ReadLine(), out var discountValue);

            while (discountValue < 0 && discountValue > price)
            {
                Console.WriteLine($"Значение скидки должно быть от 0 до {price}");
                int.TryParse(Console.ReadLine(), out discountValue);
            }

            DiscountValue = discountValue;
            
            return DiscountPrice = price - DiscountValue;
        }

        public override string GetSellInformation()
        {
            return DiscountValue != 0 ? $"На данный товар действует скидка {DiscountValue}р. " + $"Сумма с учётом скидки - {DiscountPrice}р." : null;
        }
    }
}