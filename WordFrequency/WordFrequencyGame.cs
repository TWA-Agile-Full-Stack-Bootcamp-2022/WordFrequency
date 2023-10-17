using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            if (Regex.Split(inputStr, @"\s+").Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                //split the input string with 1 to n pieces of spaces
                string[] words = Regex.Split(inputStr, @"\s+");

                Dictionary<string, int> wordFrequencyMap = new Dictionary<string, int>();

                foreach (var word in words)
                {
                    if (!wordFrequencyMap.ContainsKey(word))
                    {
                        wordFrequencyMap.Add(word, 1);
                    }
                    else
                    {
                        wordFrequencyMap[word]++;
                    }
                }

                var sortedWordFrequency = wordFrequencyMap.OrderByDescending(x => x.Value)
                .Select(x => $"{x.Key} {x.Value}").ToArray();

                return string.Join("\n", sortedWordFrequency);
            }
        }
    }
}
