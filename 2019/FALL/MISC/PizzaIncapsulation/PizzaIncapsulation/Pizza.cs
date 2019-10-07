using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaIncapsulation
{
    public class Pizza
    {
        public readonly string Name;
        public double Calories { get; private set; }
        private int toppingAmount = 0;

        public Pizza(string name)
        {
            if (name.Length > 0 && name.Length < 16) Name = name;
            else throw new ArgumentException("Название пиццы должно быть от 1 до 15 символов");
            Calories = 0;
        }

        public void SetDouth(Dough dough)
        {
            Calories += dough.Calories;
        }

        public void AddTopping(Topping topping)
        {
            toppingAmount++;
            if (toppingAmount > 10) throw new Exception("Количество добавок должно быть в диапазоне [0..10].");
            Calories += topping.Calories;
        }
    }
}
