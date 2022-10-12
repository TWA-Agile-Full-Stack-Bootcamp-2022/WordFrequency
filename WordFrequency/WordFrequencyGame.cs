using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SplitPattern = @"\s+";

        public string GetResult(string inputStr)
        {
            var inputStrArr = SplitInputStrings(inputStr);
            if (inputStrArr.Length == 1)
            {
                return inputStr + " 1";
            }

            List<Input> words = inputStrArr.GroupBy(s => s)
                .Select(g => new Input(g.Key, g.Count()))
                .OrderByDescending(g => g.WordCount)
                .ToList();
            return PrintWordsCount(words);
        }

        private static string PrintWordsCount(List<Input> words)
        {
            return string.Join("\n", words.Select(w => w.ToString()).ToList());
        }

        private static string[] SplitInputStrings(string inputStr)
        {
            return Regex.Split(inputStr, SplitPattern);
        }
    }
}