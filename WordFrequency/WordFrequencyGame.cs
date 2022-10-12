using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
                var inputWordList = ConvertInputStringToWordList(inputStr);

                //get the map for the next step of sizing the same word
                var wordListWithoutDuplicate = DeduplicateWords(inputWordList);

                var sortedWords = DescendingSortWordsByFrequency(wordListWithoutDuplicate);

                return GenerateWordFrequencyGameResult(sortedWords);
            }
        }

        private static string GenerateWordFrequencyGameResult(List<FrequencyWord> wordListWithoutDuplicate)
        {
            List<string> wordFrequencyGameOutputs = new List<string>();

            foreach (FrequencyWord w in wordListWithoutDuplicate)
            {
                string frequencyWordOutput = w.Word + " " + w.WordCount;
                wordFrequencyGameOutputs.Add(frequencyWordOutput);
            }

            return string.Join("\n", wordFrequencyGameOutputs.ToArray());
        }

        private static List<FrequencyWord> DescendingSortWordsByFrequency(List<FrequencyWord> wordListWithoutDuplicate)
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

        private static List<FrequencyWord> ConvertInputStringToWordList(string inputStr)
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
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
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
