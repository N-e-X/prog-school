namespace DiscountСalculator
{
    public interface IDiscount
    {
        int CalculateDiscountPrice(int price);
        string GetSellInformation();
    }
}
