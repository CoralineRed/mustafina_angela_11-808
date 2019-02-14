using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            if (ax == bx)
                if (y <= Math.Max(ay, by) && y >= Math.Min(ay, by))
                    return Math.Abs(ax - x);
            if (ay == by)
                if (x <= Math.Max(ax, bx) && x >= Math.Min(ax, bx))
                    return Math.Abs(ay - y);
            // Находим прямую y = k*x + b, проходящую через отрезок.
            double k = (double)(ay - by) / (ax - bx);
            double b = (double)(ax * by - bx * ay) / (ax - bx);
            // Находим прямую y = -x/k + c, проходящую через точку и перпендикулярную отрезку.
            double c = y + x / k;
            double x1 = (c - b) / (k + 1 / k);
            double y1 = k * x1 + b;
            // Если перпендикуляр из точки падает на отрезок, возвращаем его длину.
            if (x1 <= Math.Max(ax, bx) && x1 >= Math.Min(ax, bx))
                return GetDistanceBetweenPoints(x, y, x1, y1);
            else
                // В ином случае возвращаем расстояние до ближайшего конца отрезка.
                return Math.Min(GetDistanceBetweenPoints(x, y, ax, ay),
                    GetDistanceBetweenPoints(x, y, bx, by));
        }

        public static double GetDistanceBetweenPoints(double ax, double ay, double bx, double by)
        {
            return Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
        }
    }
}
