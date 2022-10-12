using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            var inputStrArr = SplitInputStrings(inputStr);
            if (inputStrArr.Length == 1)
            {
                return inputStr + " 1";
            }

            var inputWords = SplitInputStringToWords(inputStrArr);
            List<Input> words = CountWords(inputWords);
            words.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            return PrintWordsCount(words);
        }

        private static string PrintWordsCount(List<Input> words)
        {
            return string.Join("\n", words.Select(w => w.ToString()).ToList());
        }

        private static string[] SplitInputStrings(string inputStr)
        {
            return Regex.Split(inputStr, @"\s+");
        }

        private List<Input> CountWords(List<Input> inputList)
        {
            return GetListMap(inputList).ToList()
                .Select(entry => new Input(entry.Key, entry.Value.Count))
                .ToList();
        }

        private static List<Input> SplitInputStringToWords(string[] inputStrArr)
        {
            return inputStrArr.Select(w => new Input(w, 1)).ToList<Input>();
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            return inputList.GroupBy(input => input.Value)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}