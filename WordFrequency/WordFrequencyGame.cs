using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SPACE_DELIMITER = @"\s+";

        public string GetResult(string sentence)
        {
            string[] words = Regex.Split(sentence, SPACE_DELIMITER);
            if (words.Length == 1)
            {
                return sentence + " 1";
            }
            else
            {
                List<WordFrequency> wordFrequencyList = BuildWordFrequencyList(words);

                string[] wordFrequencyInfo = wordFrequencyList
                    .Select(wordFrequency => wordFrequency.Word + " " + wordFrequency.Count)
                    .ToArray();

                return string.Join("\n", wordFrequencyInfo);
            }
        }

        private static List<WordFrequency> BuildWordFrequencyList(string[] words)
        {
            return words
                .Select(word => new WordFrequency(word, 1))
                .GroupBy(wordFrequency => wordFrequency.Word)
                .Select(group => new WordFrequency(group.Key, group.Count()))
                .OrderByDescending(word => word.Count)
                .ToList();
        }
    }
}
