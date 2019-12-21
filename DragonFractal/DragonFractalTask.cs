// В этом пространстве имен содержатся средства для работы с изображениями. Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System.Drawing;
using System;
using System.Collections;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
            double x = 1;
            double y = 0;
            double angle45 = Math.PI * 45 / 180;
            double angle135 = Math.PI * 135 / 180;
            var random = new Random(seed);
            for (int i = 0; i < iterationsCount; i++)
            {
                var number = random.Next(1);
                if (number == 0)
                {
                    double x1 = (x * Math.Cos(angle45) - y * Math.Sin(angle45)) / Math.Sqrt(2);
                    double y1 = (x * Math.Sin(angle45) + y * Math.Cos(angle45)) / Math.Sqrt(2);
                    x = x1;
                    y = y1;
                }
                else if (number == 1)
                {
                    double x1 = (x * Math.Cos(angle135) - y * Math.Sin(angle135)) / Math.Sqrt(2) + 1;
                    double y1 = (x * Math.Sin(angle135) + y * Math.Cos(angle135)) / Math.Sqrt(2);
                    x = x1;
                    y = y1;
                }
                pixels.SetPixel(x, y);
            }
        }
    }
}