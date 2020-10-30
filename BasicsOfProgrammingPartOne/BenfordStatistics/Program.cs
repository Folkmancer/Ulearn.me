using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenfordStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var res1 = GetBenfordStatistics("1");
            var res2 = GetBenfordStatistics("abc");
            var res3 = GetBenfordStatistics("123 456 789");
            var res4 = GetBenfordStatistics("abc 123 def 456 gf 789 i");
        }

        //public static int[] GetBenfordStatistics(string text)
        //{
        //    var statistics = new int[10];

        //    var words = text.Split(' ').Where(word => !string.IsNullOrEmpty(word) && char.IsDigit(word[0]));

        //    foreach (var word in words)
        //    {
        //        var index = word[0] - '0';
        //        statistics[index]++;
        //    }

        //    return statistics;
        //}

        public static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]) && (i == 0 || !char.IsDigit(text[i - 1])))
                {
                    var index = text[i] - '0';
                    statistics[index]++;
                }
            }

            return statistics;
        }

        public static string ReplaceIncorrectSeparators(string text)
        {
            var separator = new char[] { ' ', ',', ';', '-' };
            var splitedText = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            return string.Join("\t", splitedText);
        }
    }
}
