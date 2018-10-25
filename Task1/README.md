# Описание

Классы различных типов скидок вынесены в DiscountTypes/
Все классы скидок происходят от абстрактного класса Discount

В приложении реализован динамический выбор типа скидки благодаря использованию рефлексии, что помогло избежать конструкции switch-case:

Для добавления нового типа скидки необходимо его "зарегистрировать", т.е. прописать, в классе DiscountTypeRegister в методе GetTypeList():
```
return DiscountTypes ?? (DiscountTypes = new List<TypeWithName>()
{
    new TypeWithName(typeof(CardDiscount), "Скидка по карте (500р.)"),
    new TypeWithName(typeof(PrecentageDiscount), "Скидка по проценту"),
    new TypeWithName(typeof(CostDiscount), "Скидка по сумме от стоимости"),
    // по аналогии указать тип скидки (класс) и её название
});
```
