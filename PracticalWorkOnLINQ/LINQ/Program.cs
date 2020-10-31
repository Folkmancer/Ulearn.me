using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var even = numbers.Where(x => x % 2 == 0);
            var squares = even.Select(x => x * x);
            var squaresWithoutOne = squares.Skip(1);
            var secondAndThirdSquares = squaresWithoutOne.Take(2);
            var result = secondAndThirdSquares.ToArray();

            foreach (var num in ParseNumbers(new[] { "-0", "+0000" }))
            {
                Console.WriteLine(num);
            }

            foreach (var num in ParseNumbers(new List<string> { "1", "", "-03", "0" }))
            {
                Console.WriteLine(num);
            }

            foreach (var point in ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
            {
                Console.WriteLine(point.X + " " + point.Y);
            }

            foreach (var point in ParsePoints(new List<string> { "+01 -0042" }))
            {
                Console.WriteLine(point.X + " " + point.Y);
            }

            var classes = new[]
            {
                new Classroom { Students = { "Pavel", "Ivan", "Petr" }, },
                new Classroom { Students = {"Anna", "Ilya", "Vladimir" }, },
                new Classroom { Students = { "Bulat", "Alex", "Galina" }, }
            };

            var allStudents = GetAllStudents(classes);
            Array.Sort(allStudents);
            Console.WriteLine(string.Join(" ", allStudents));

            foreach (var point in GetNeighbours(new Point(3, 4)))
            {
                Console.WriteLine(point.X + " " + point.Y);
            }

            var text = new[] {
                "Hello, hello, hello, how low",
                "",
                "With the lights out, it's less dangerous",
                "Here we are now; entertain us",
                "I feel stupid and contagious",
                "Here we are now; entertain us",
                "A mulatto, an albino, a mosquito, my libido...",
                "Yeah, hey"
            };

            foreach (var word in GetSortedWords(text))
            {
                Console.WriteLine(word);
            }

            var textAboutBox = "A box of biscuits, a box of mixed biscuits, and a biscuit mixer.";

            foreach (var word in GetSortedWords(textAboutBox))
            {
                Console.WriteLine(word);
            }

            var textAboutEggs = "Each Easter Eddie eats eighty Easter eggs.";

            foreach (var word in GetSortedWords(textAboutEggs))
            {
                Console.WriteLine(word);
            }

            Console.WriteLine(GetLongest(new[] { "azaz", "as", "sdsd" }));
            Console.WriteLine(GetLongest(new[] { "zzzz", "as", "sdsd" }));
            Console.WriteLine(GetLongest(new[] { "as", "12345", "as", "sds" }));

            foreach (var word in GetMostFrequentWords(textAboutBox, 2))
            {
                Console.WriteLine(word);
            }

            foreach (var word in GetMostFrequentWords(textAboutEggs, 3))
            {
                Console.WriteLine(word);
            }

            var documents = new[]
            {
                new Document { Id = 1, Text = "Hello world!" },
                new Document { Id = 2, Text = "World, world, world... Just words..." },
                new Document { Id = 3, Text = "Words — power" },
                new Document {Id = 4, Text = "" }
            };

            var index = BuildInvertedIndex(documents);
        }

        public static int[] ParseNumbers(IEnumerable<string> lines)
        {
            return lines
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => int.Parse(x))
                .ToArray();
        }

        public static List<Point> ParsePoints(IEnumerable<string> lines)
        {
            return lines
                .Select(x => x.Split(' ').Select(y => int.Parse(y)))
                .Select(x => new Point(x.First(), x.Last()))
                .ToList();
        }

        public static string[] GetAllStudents(Classroom[] classes)
        {
            return classes
                .SelectMany(x => x.Students)
                .ToArray();
        }

        public static IEnumerable<Point> GetNeighbours(Point p)
        {
            int[] d = { -1, 0, 1 };

            return d.SelectMany(y => d.Select(x => new Point(p.X + x, p.Y + y)))
                .Where(point => !point.Equals(p))
                .ToList();
        }

        public static string[] GetSortedWords(params string[] textLines)
        {
            return textLines
                .SelectMany(x => Regex.Split(x, @"\W+"))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.ToLower())
                .Distinct()
                .OrderBy(x => x)
                .ToArray();
        }

        public static List<string> GetSortedWords(string text)
        {
            return Regex.Split(text, @"\W+")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.ToLower())
                .Distinct()
                .Select(x => (x.Length, x))
                .OrderBy(x => x)
                .Select(x => x.x)
                .ToList();
        }

        public static string GetLongest(IEnumerable<string> words)
        {
            return words
                .Min(word => (-word.Length, word))
                .word;
        }

        public static Tuple<string, int>[] GetMostFrequentWords(string text, int count)
        {
            return Regex.Split(text, @"\W+")
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .GroupBy(word => word.ToLower())
                .Select(x => Tuple.Create(x.Key, x.Count()))
                .OrderByDescending(x => x.Item2)
                .ThenBy(x => x.Item1)
                .Take(count)
                .ToArray();
        }

        public static ILookup<string, int> BuildInvertedIndex(Document[] documents)
        {
            return documents
                .SelectMany(
                    document => Regex.Split(document.Text, @"\W+")
                        .Where(word => !string.IsNullOrWhiteSpace(word))
                        .Select(word => word.ToLower())
                        .Distinct()
                        .Select(word => new { Word = word, Id = document.Id })
                )
                .ToLookup(x => x.Word, x => x.Id);
        }
    }
}