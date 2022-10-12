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
            Dictionary<string, List<FrequencyWord>> wordMap = GetListMap(inputWordList);

            List<FrequencyWord> wordListWithoutDuplicate = new List<FrequencyWord>();
            foreach (var entry in wordMap)
            {
                FrequencyWord frequencyWord = new FrequencyWord(entry.Key, entry.Value.Count);
                wordListWithoutDuplicate.Add(frequencyWord);
            }

            return wordListWithoutDuplicate;
        }

        private List<FrequencyWord> ConvertInputStringToWordList(string inputStr)
        {
            string[] inputWords = Regex.Split(inputStr, @"\s+");

            List<FrequencyWord> inputWordList = new List<FrequencyWord>();
            foreach (var word in inputWords)
            {
                FrequencyWord frequencyWord = new FrequencyWord(word, 1);
                inputWordList.Add(frequencyWord);
            }

            return inputWordList;
        }

        private Dictionary<string, List<FrequencyWord>> GetListMap(List<FrequencyWord> inputWordList)
        {
            Dictionary<string, List<FrequencyWord>> wordMap = new Dictionary<string, List<FrequencyWord>>();
            foreach (var inputWord in inputWordList)
            {
                if (!wordMap.ContainsKey(inputWord.Word))
                {
                    List<FrequencyWord> sameWordList = new List<FrequencyWord>();
                    sameWordList.Add(inputWord);
                    wordMap.Add(inputWord.Word, sameWordList);
                }
                else
                {
                    wordMap[inputWord.Word].Add(inputWord);
                }
            }

            return wordMap;
        }
    }
}