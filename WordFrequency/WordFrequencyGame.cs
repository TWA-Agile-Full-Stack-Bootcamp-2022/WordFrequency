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
                List<WordFrequency> wordFrequencyList = words
                                    .Select(word => new WordFrequency(word, 1))
                                    .ToList();

                List<WordFrequency> list = wordFrequencyList
                    .GroupBy(wordFrequency => wordFrequency.Word)
                    .Select(group => new WordFrequency(group.Key, group.Count()))
                    .ToList();

                wordFrequencyList = list;

                wordFrequencyList.Sort((w1, w2) => w2.Count - w1.Count);

                List<string> strList = new List<string>();

                //stringJoiner joiner = new stringJoiner("\n");
                foreach (WordFrequency w in wordFrequencyList)
                {
                    string s = w.Word + " " + w.Count;
                    strList.Add(s);
                }

                return string.Join("\n", strList.ToArray());
            }
        }
    }
}
