using System;
using System.IO;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            double chisl = (bx - ax) * (y - ay) - (by - ay) * (x - ax);
            double znam = Math.Sqrt(Math.Pow((by - ay), 2) + Math.Pow((bx - ax), 2));
            File.WriteAllText("C:\test\new.txt", "123456");
            return Math.Abs(chisl / znam);
            
        }
	}
}