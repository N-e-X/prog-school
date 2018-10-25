using System;

namespace DiscountСalculator
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        private Discount _discount;
        public Discount Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                CalculateDiscountPrice();
            }
        }
        
        public int CalculateDiscountPrice()
        {
           return Discount?.CalculateDiscountPrice(Price) ?? Price;
        }

        public string GetSellInformation()
        {
            return Discount?.GetSellInformation() ?? "В настоящий момент на данный товар нет скидок.";
        }
    }        
}
