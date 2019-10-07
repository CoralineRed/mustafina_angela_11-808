using System;

namespace PizzaIncapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            Pizza pizza = null;
            while (line != "END")
            {
                var s = line.Split();
                if (s[0] == "Pizza") pizza = new Pizza(s[1]);
                else if (s[0] == "Dough") pizza.SetDouth(new Dough(s[1], s[2], int.Parse(s[3])));
                else if (s[0] == "Topping") pizza.AddTopping(new Topping(s[1], int.Parse(s[2])));
                line = Console.ReadLine();
            }
            Console.WriteLine(pizza.Name + " - " + pizza.Calories + " Calories");
        }
    }
}
