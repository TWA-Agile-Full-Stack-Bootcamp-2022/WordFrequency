using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string WordSplitter = @"\s+";

        public string GetResult(string sentence)
        {
            var inputWords = ConvertInputStringToWordList(sentence);

            var groupedWords = GroupFrequencyWords(inputWords);

            var sortedWords = DescendingSortWordsByFrequency(groupedWords);

            return GenerateWordFrequencyGameResult(sortedWords);
        }

        private string GenerateWordFrequencyGameResult(List<FrequencyWord> wordsWithoutDuplicate)
        {
            return string.Join("\n", wordsWithoutDuplicate.Select(word => word.ToString()).ToArray());
        }

        private List<FrequencyWord> DescendingSortWordsByFrequency(List<FrequencyWord> wordsWithoutDuplicate)
        {
            wordsWithoutDuplicate.Sort((firstWord, secondWord) => secondWord.WordCount - firstWord.WordCount);
            return wordsWithoutDuplicate;
        }

        private List<FrequencyWord> GroupFrequencyWords(List<FrequencyWord> words)
        {
            return words.GroupBy(word => word.Word)
                .Select(group => new FrequencyWord(group.Key, group.Sum(word => word.WordCount)))
                .ToList();
        }

        private List<FrequencyWord> ConvertInputStringToWordList(string sentence)
        {
            var words = Regex.Split(sentence, WordSplitter);

            return words.Select(word => new FrequencyWord(word, 1)).ToList();
        }
    }
}