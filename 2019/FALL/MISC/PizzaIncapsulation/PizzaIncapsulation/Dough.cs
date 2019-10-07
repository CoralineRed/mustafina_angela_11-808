using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaIncapsulation
{
    public class Dough
    {
        public readonly double Calories;

        public Dough(string flour, string bakingTechnic, int weight)
        {
            Calories = 2;
            if (flour == "White") Calories *= 1.5;
            else if (flour == "Wholegrain") Calories *= 1;
            else throw new ArgumentException("Invalid type of dough.");
            if (bakingTechnic == "Crispy") Calories *= 0.9;
            else if (bakingTechnic == "Chewy") Calories *= 1.1;
            else if (bakingTechnic == "Homemade") Calories *= 1;
            else throw new ArgumentException("Invalid type of dough.");
            if (weight > 0 && weight < 201) Calories *= weight;
            else throw new ArgumentException("Dough weight should be in the range [1..200].");
        }
    }
}
