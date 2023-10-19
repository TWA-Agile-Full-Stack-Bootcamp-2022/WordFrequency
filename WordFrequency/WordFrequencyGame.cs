using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SPACE = @"\s+";

        public string CountWords(string inputStr)
        {
            List<WordCount> resultWordCountList = ToWordCountList(inputStr);
            resultWordCountList.Sort((w1, w2) => w2.Count - w1.Count);
            List<string> strList = new List<string>();
            resultWordCountList.ForEach(w => strList.Add(w.Word + " " + w.Count));
            return string.Join("\n", strList.ToArray());
        }

        private List<WordCount> ToWordCountList(string inputStr)
        {
            string[] words = Regex.Split(inputStr, SPACE);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dictionary.TryGetValue(word, out int count))
                {
                    dictionary[word] = count+1;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            List<WordCount> wordCounts = new List<WordCount>();
            foreach (var entry in dictionary)
            {
                wordCounts.Add(new WordCount(entry.Key, entry.Value));
            }

            return wordCounts;
        }
    }
}
