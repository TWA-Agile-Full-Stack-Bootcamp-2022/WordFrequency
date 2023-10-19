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
            if (Regex.Split(inputStr, SPACE).Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                //split the input string with 1 to n pieces of spaces
                string[] words = Regex.Split(inputStr, SPACE);

                List<WordCount> originWordCountList = new List<WordCount>();
                foreach (var word in words)
                {
                    WordCount input = new WordCount(word, 1);
                    originWordCountList.Add(input);
                }

                //get the map for the next step of sizing the same word
                Dictionary<string, List<WordCount>> word2WordCountList = GetListMap(originWordCountList);

                List<WordCount> resultWordCountList = new List<WordCount>();
                foreach (var entry in word2WordCountList)
                {
                    WordCount input = new WordCount(entry.Key, entry.Value.Count);
                    resultWordCountList.Add(input);
                }

                resultWordCountList.Sort((w1, w2) => w2.Count - w1.Count);

                List<string> strList = new List<string>();

                foreach (WordCount w in resultWordCountList)
                {
                    string s = w.Word + " " + w.Count;
                    strList.Add(s);
                }

                return string.Join("\n", strList.ToArray());
            }
        }

        private Dictionary<string, List<WordCount>> GetListMap(List<WordCount> wordCountList)
        {
            Dictionary<string, List<WordCount>> map = new Dictionary<string, List<WordCount>>();
            foreach (var wordCount in wordCountList)
            {
                if (!map.ContainsKey(wordCount.Word))
                {
                    List<WordCount> arr = new List<WordCount>();
                    arr.Add(wordCount);
                    map.Add(wordCount.Word, arr);
                }
                else
                {
                    map[wordCount.Word].Add(wordCount);
                }
            }

            return map;
        }
    }
}
