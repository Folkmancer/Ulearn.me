using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine(GetNeighbours());
        }

        public static string[] GetAllStudents(Classroom[] classes)
        {
            return classes
                .SelectMany(x => x.Students)
                .ToArray();
        }

        /*public static IEnumerable<int> GetNeighbours(/*Point p)
        {
            int[] d = { -1, 0, 1 };
            var c = d.SelectMany(y => d.Select(x => y * x));
            return c;
        }*/

        public static IEnumerable<Point> GetNeighbours()
        {
            int[] d = { -1, 0, 1 };
            return new List<Point> { new Point(3,2) };
        }
    }

    public class Classroom
    {
        public List<string> Students = new List<string>();
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X, Y;
    }
}
