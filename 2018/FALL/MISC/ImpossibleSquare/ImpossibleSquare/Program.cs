using System;
using System.Diagnostics;
using System.Drawing;

namespace RefactorMe
{
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
            double heigth = size / 10;

            for (int i = 0; i < anglesAmount; i++)
            {
                Point point = new Point(start.x, start.y);
                point = Drawer.Go(point, size, rotationAngle + turnAngle * i);
                point = Drawer.Go(point, heigth / Math.Sin(Math.PI / anglesAmount), rotationAngle + turnAngle * i + Math.PI / anglesAmount);
                start = new Point(point.x, point.y);
                double middleSide = size - heigth / Math.Tan(angle / 2) + heigth / Math.Tan(Math.PI / anglesAmount);
                point = Drawer.Go(point, middleSide, rotationAngle + turnAngle * i + Math.PI);
                double innerSide = middleSide - heigth / Math.Tan(angle / 2) - heigth / Math.Tan(angle);
                Drawer.Go(point, innerSide, rotationAngle + angle + turnAngle * i);
            }
            
            Drawer.ShowResult();
        }
    }
}
