using System;

namespace DiscountСalculator
{
    public abstract class Discount : IDiscount
    {
        public int DiscountValue { get; set; }
        public int DiscountPrice { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }

        public void GetDate()
        {
            Console.WriteLine("Введите дату начала действия скидки");
            DateTime.TryParse(Console.ReadLine(), out var startSellDate);

            if (startSellDate != DateTime.MinValue)
            {
                StartSellDate = startSellDate;
            }

            Console.WriteLine("Введите дату окончания действия скидки");

            DateTime.TryParse(Console.ReadLine(), out var endSellDate);

            if (endSellDate != DateTime.MinValue)
            {
                EndSellDate = endSellDate;
            }
        }

        public abstract int CalculateDiscountPrice(int price);

        public abstract string GetSellInformation();
    }
}