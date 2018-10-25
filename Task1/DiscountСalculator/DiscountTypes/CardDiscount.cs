using System;

namespace DiscountСalculator.DiscountTypes
{
    public class CardDiscount : Discount, IDiscount
    {
        public CardDiscount()
        {
            DiscountValue = 500;
        }

        public override int CalculateDiscountPrice(int price)
        {
            GetDate();
            return DiscountPrice =
                StartSellDate.HasValue &&
                EndSellDate.HasValue &&
                StartSellDate <= DateTime.UtcNow &&
                EndSellDate >= DateTime.UtcNow
                    ? (price - DiscountValue > 0 ? price - DiscountValue : 0)
                    : price;
        }

        public override string GetSellInformation()
        {
            return StartSellDate.HasValue && EndSellDate.HasValue
                ? $"На данный товар действует скидка {DiscountValue}р. в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                  $"Сумма с учётом скидки - {DiscountPrice}р." : null;
        }
    }
}