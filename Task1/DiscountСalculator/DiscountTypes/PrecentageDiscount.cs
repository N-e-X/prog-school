using System;

namespace DiscountСalculator.DiscountTypes
{
    public class PrecentageDiscount : Discount
    {
        public override int CalculateDiscountPrice(int price)
        {
            Console.WriteLine("Введите значение скидки на товар (в % от общей стоимости)");
            int.TryParse(Console.ReadLine(), out var discountValue);

            while (discountValue > 100 && discountValue < 0)
            {
                Console.WriteLine("Значение скидки должно быть в пределах от 0 до 100");
                int.TryParse(Console.ReadLine(), out discountValue);
            }

            DiscountValue = discountValue;

            GetDate();

            return DiscountPrice = 
                   DiscountValue != 0 &&
                   StartSellDate.HasValue &&
                   EndSellDate.HasValue &&
                   StartSellDate <= DateTime.UtcNow &&
                   EndSellDate >= DateTime.UtcNow
                ? price - (price * DiscountValue / 100)
                : price;
        }

        public override string GetSellInformation()
        {
            return DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue
                ? $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                  $"Сумма с учётом скидки - {DiscountPrice}р." : null;
        }
    }
}