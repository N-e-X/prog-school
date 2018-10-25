using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountСalculator.DiscountTypes;

namespace DiscountСalculator
{
    /// <summary>
    /// Класс, регистрирующий типы существующих скидок при запуске программы
    /// </summary>

    public class DiscountTypeRegister
    {
        public static List<TypeWithName> DiscountTypes { get; private set; }
        private DiscountTypeRegister() { }

        /// <summary>
        /// Метод для получения списка типов скидок и их названий.
        /// Для получения типа использовать аксессор Type.
        /// Название генерируется через ToString().
        /// </summary>
        public static List<TypeWithName> GetTypeList()
        {
            return DiscountTypes ?? (DiscountTypes = new List<TypeWithName>()
            {
                new TypeWithName(typeof(CardDiscount), "Скидка по карте (500р.)"),
                new TypeWithName(typeof(PrecentageDiscount), "Скидка по проценту"),
                new TypeWithName(typeof(CostDiscount), "Скидка по сумме от стоимости"),
            });
        }

        public class TypeWithName
        {
            public Type Type { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }

            public TypeWithName(Type t, string n)
            {
                Type = t;
                Name = n ?? throw new ArgumentNullException(nameof(n));
            }
        }

    }
}
