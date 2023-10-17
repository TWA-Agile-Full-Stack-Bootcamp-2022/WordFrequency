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
                List<WordFrequency> wordFrequencyList = new List<WordFrequency>();
                foreach (var word in words)
                {
                    WordFrequency wordFrequency = new WordFrequency(word, 1);
                    wordFrequencyList.Add(wordFrequency);
                }

                //get the map for the next step of sizing the same word
                Dictionary<string, List<WordFrequency>> map = GetListMap(wordFrequencyList);

                List<WordFrequency> list = new List<WordFrequency>();
                foreach (var entry in map)
                {
                    WordFrequency input = new WordFrequency(entry.Key, entry.Value.Count);
                    list.Add(input);
                }

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

        private Dictionary<string, List<WordFrequency>> GetListMap(List<WordFrequency> inputList)
        {
            Dictionary<string, List<WordFrequency>> map = new Dictionary<string, List<WordFrequency>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Word))
                {
                    List<WordFrequency> arr = new List<WordFrequency>();
                    arr.Add(input);
                    map.Add(input.Word, arr);
                }
                else
                {
                    map[input.Word].Add(input);
                }
            }

            return map;
        }
    }
}
