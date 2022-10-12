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
            var inputWordList = ConvertInputStringToWordList(inputStr);

            var wordListWithoutDuplicate = DeduplicateWords(inputWordList);

            var sortedWords = DescendingSortWordsByFrequency(wordListWithoutDuplicate);

            return GenerateWordFrequencyGameResult(sortedWords);
        }

        private string GenerateWordFrequencyGameResult(List<FrequencyWord> wordListWithoutDuplicate)
        {
            return string.Join("\n", wordListWithoutDuplicate.Select(word => word.ToString()).ToArray());
        }

        private List<FrequencyWord> DescendingSortWordsByFrequency(List<FrequencyWord> wordListWithoutDuplicate)
        {
            wordListWithoutDuplicate.Sort((w1, w2) => w2.WordCount - w1.WordCount);
            return wordListWithoutDuplicate;
        }

        private List<FrequencyWord> DeduplicateWords(List<FrequencyWord> inputWordList)
        {
            return inputWordList.GroupBy(word => word.Word)
                .Select(group => new FrequencyWord(group.Key, group.Sum(word => word.WordCount)))
                .ToList();
        }

        private List<FrequencyWord> ConvertInputStringToWordList(string inputStr)
        {
            var inputWords = Regex.Split(inputStr, @"\s+");

            return inputWords.Select(word => new FrequencyWord(word, 1)).ToList();
        }
    }
}