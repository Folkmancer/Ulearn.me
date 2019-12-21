using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            foreach (var line in GetSentences(text))
            {
                sentencesList.Add(GetWords(line));
            }
            return sentencesList;
        }

        public static List<string> GetSentences(string text)
        {
            var sentences = new List<string>();
            string output = new string(text.Where(c => !char.IsControl(c)).ToArray());
            foreach (var line in output.Split('.', '!', '?', ';', ':', '(', ')'))
            {
                if (line.Trim().Length != 0) sentences.Add(line);
            }
            return sentences;
        }

        public static List<string> GetWords(string sentence)
        {
            var words = new List<string>();
            string output = new string(sentence.Where(c => !char.IsControl(c)).Where(c => char.IsLetter(c)).ToArray());
            foreach (var word in sentence.Split(' ').Where(c => !char.IsSeparator(c)))
            {
                words.Add(word);
            }
            return words;
        }
    }
}