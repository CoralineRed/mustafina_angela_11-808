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
            if (x1 <= Math.Max(ax, bx) && x1 >= Math.Min(ax, bx))
                return Math.Sqrt((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y));
            else
                return Math.Sqrt(Math.Min((ax - x) * (ax - x) + (ay - y) * (ay - y),
                    (bx - x) * (bx - x) + (by - y) * (by - y)));
		}
	}
}