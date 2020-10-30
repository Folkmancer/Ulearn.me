using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();

            foreach (var sentence in GetSentences(text))
            {
                var result = GetWords(sentence);
                
                if (result.Any())
                    sentencesList.Add(result);
            }

            return sentencesList;
        }

        public static List<string> GetSentences(string text)
        {
            var sentences = new List<string>();

            foreach (var sentence in text.Split('.', '!', '?', ';', ':', '(', ')'))
            {
                if (!string.IsNullOrWhiteSpace(sentence)) 
                    sentences.Add(sentence.Trim());
            }

            return sentences;
        }

        public static List<string> GetWords(string sentence)
        {
            var words = new List<string>();
            var separators = sentence.Where(x => !char.IsLetter(x) && x != '\'').Distinct().ToArray();
            
            foreach (var word in sentence.Split(separators))
            {
                if (!string.IsNullOrWhiteSpace(word))
                    words.Add(word.Trim().ToLower());
            }

            return words;
        }
    }
}