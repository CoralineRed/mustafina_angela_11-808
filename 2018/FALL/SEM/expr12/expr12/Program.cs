//Мустафина Анжела

//Самолёт должен набрать высоту h метров в течение первых t секунд полёта и удерживать её
//в течение всего полёта. Разрешён набор высоты со скоростью не более чем v метров в секунду.
//До полного набора высоты запрещено снижаться. Известно, что уши заложены в те и только
//те моменты времени, когда самолёт поднимается со скоростью более x метров в секунду.
//Посчитайте минимальное и максимальное возможное время, в течение которого у пассажиров будут
//заложены уши.

using System;

namespace expr12
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            if (t * x >= h) Console.WriteLine("min time = 0");
            else Console.WriteLine("min time = " + ((double)(h - t * x) / (v - x)).ToString());
            if (t * (x + 1) >= h) Console.WriteLine("max time = " + t.ToString());
            else Console.WriteLine("max time = " + (h - t * x).ToString());
            Console.WriteLine(t - (h - t * x));
            Console.ReadKey();
        }
    }
}
