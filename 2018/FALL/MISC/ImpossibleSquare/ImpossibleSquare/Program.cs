using System;
using System.Diagnostics;
using System.Drawing;

namespace RefactorMe
{
    // ## Прочитайте! ##
    //
    // Ваша задача привести код в этом файле в порядок. 
    // Для начала запустите эту программу. Для этого в VS в проект подключите сборку System.Drawing.

    // Переименуйте всё, что называется неправильно. Это можно делать комбинацией клавиш Ctrl+R, Ctrl+R (дважды нажать Ctrl+R).
    // Повторяющиеся части кода вынесите во вспомогательные методы. Это можно сделать выделив несколько строк кода и нажав Ctrl+R, Ctrl+M
    // Избавьтесь от всех зашитых в коде числовых констант — положите их в переменные с понятными именами.
    // 
    // После наведения порядка проверьте, что ваш код стал лучше. 
    // На сколько проще после ваших переделок стало изменить размер фигуры? Повернуть её на некоторый угол? 
    // Научиться рисовать невозможный треугольник, вместо квадрата?

    public struct Point
    {
        public float x, y;

        public Point(float p1, float p2)
        {
            x = p1;
            y = p2;
        }
    }

    class Drawer
    {
        static Bitmap image = new Bitmap(800, 600);
        static Graphics graphics;

        public static void Initialize()
        {
            image = new Bitmap(800, 600);
            graphics = Graphics.FromImage(image);
        }

        /// <summary>
        /// Делает шаг из точки begin длиной dist в направлении angle и рисует пройденную траекторию.
        /// Возвращает конечную точку типа Point.
        /// </summary>
        /// <param name="begin">начальная точка</param>
        /// <param name="dist">расстояние</param>
        /// <param name="angle">направление</param>
        /// <returns></returns>
        public static Point Go(Point begin, double dist, double angle)
        {
            Point end = new Point(0, 0);
            end.x = (float)(begin.x + dist * Math.Cos(angle));
            end.y = (float)(begin.y + dist * Math.Sin(angle));
            graphics.DrawLine(Pens.Yellow, begin.x, begin.y, end.x, end.y);
            return end;
        }

        public static void ShowResult()
        {
            image.Save("result.bmp");
            Process.Start("result.bmp");
        }
    }

    public class StrangeThing
    {
        public static void Main()
        {
            int anglesAmount = 3;
            Point start = new Point(200, 150);
            double rotationAngle = 0;
            double size = 150;

            Drawer.Initialize();
            double angle = Math.PI * (anglesAmount - 2) / anglesAmount;
            double turnAngle = Math.PI - angle;
            double h = size / 10;

            for (int i = 0; i < anglesAmount; i++)
            {
                Point point = new Point(start.x, start.y);
                point = Drawer.Go(point, size, rotationAngle + turnAngle * i);
                point = Drawer.Go(point, h / Math.Sin(Math.PI / anglesAmount), rotationAngle + turnAngle * i + Math.PI / anglesAmount);
                start = new Point(point.x, point.y);
                double middle = size - h / Math.Tan(angle / 2) + h / Math.Tan(Math.PI / anglesAmount);
                point = Drawer.Go(point, middle, rotationAngle + turnAngle * i + Math.PI);
                double innerSide = middle - h / Math.Tan(angle / 2) - h / Math.Tan(angle);
                Drawer.Go(point, innerSide, rotationAngle + angle + turnAngle * i);
            }
            
            Drawer.ShowResult();
        }
    }
}
