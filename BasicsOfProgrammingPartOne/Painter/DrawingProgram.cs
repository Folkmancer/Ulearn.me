using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RefactorMe
{
    class Painter
    {
        static float x;
        static float y;
        static Graphics graphics;

        public static void Initialize(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        { 
            x = x0;
            y = y0; 
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));

            graphics.DrawLine(pen, x, y, x1, y1);

            x = x1;
            y = y1;
        }

        public static void ChangePosition(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double angleRotation, Graphics graphics)
        {
            // angleRotation пока не используется, но будет использоваться в будущем
            Painter.Initialize(graphics);

            var size = Math.Min(width, height);
            var horizontalLineLength = size * 0.375;
            var verticalLineLength = size * 0.04;
            var obliqueLineLength = verticalLineLength * Math.Sqrt(2);

            var diagonalLength = Math.Sqrt(2) * (horizontalLineLength + verticalLineLength) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Painter.SetPosition(x0, y0);

            DrawSide(horizontalLineLength, verticalLineLength, obliqueLineLength, 0);
            DrawSide(horizontalLineLength, verticalLineLength, obliqueLineLength, -Math.PI / 2);
            DrawSide(horizontalLineLength, verticalLineLength, obliqueLineLength, Math.PI);
            DrawSide(horizontalLineLength, verticalLineLength, obliqueLineLength, Math.PI / 2);
        }

        private static void DrawSide(
            double horizontalLineLength, 
            double verticalLineLength, 
            double obliqueLineLength, 
            double angle
        )
        {
            Painter.DrawLine(Pens.Yellow, horizontalLineLength, angle);
            Painter.DrawLine(Pens.Yellow, obliqueLineLength, angle + Math.PI / 4);
            Painter.DrawLine(Pens.Yellow, horizontalLineLength, angle + Math.PI);
            Painter.DrawLine(Pens.Yellow, horizontalLineLength - verticalLineLength, angle + Math.PI / 2);

            Painter.ChangePosition(verticalLineLength, angle - Math.PI);
            Painter.ChangePosition(obliqueLineLength, angle + 3 * Math.PI / 4);
        }
    }
}