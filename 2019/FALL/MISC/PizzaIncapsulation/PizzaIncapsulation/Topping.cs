using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaIncapsulation
{
    public class Topping
    {
        public readonly double Calories;

        public Topping(string topping, int weight)
        {
            Calories = 2;
            if (topping == "Meat") Calories *= 1.2;
            else if (topping == "Veggies") Calories *= 0.8;
            else if (topping == "Sauce") Calories *= 0.9;
            else if (topping == "Cheese") Calories *= 1.1;
            else throw new ArgumentException("Cannot place " + topping + " on top of your pizza.");
            if (weight > 0 && weight < 51) Calories *= weight;
            else throw new ArgumentException(topping + " weight should be in the range [1..50].");
        }
    }
}
