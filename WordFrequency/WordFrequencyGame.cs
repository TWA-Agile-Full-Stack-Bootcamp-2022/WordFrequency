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
            if (Regex.Split(inputStr, @"\s+").Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                //split the input string with 1 to n pieces of spaces
                var inputWords = SplitInputStringToWords(inputStr);

                //get the map for the next step of sizing the same word
                List<Input> words = CountWords(inputWords);

                words.Sort((w1, w2) => w2.WordCount - w1.WordCount);

                List<string> strList = words.Select(w => w.Value + " " + w.WordCount).ToList<string>();

                return string.Join("\n", strList.ToArray());
            }
        }

        private List<Input> CountWords(List<Input> inputList)
        {
            Dictionary<string, List<Input>> map = GetListMap(inputList);

            List<Input> list = new List<Input>();
            foreach (var entry in map)
            {
                Input input = new Input(entry.Key, entry.Value.Count);
                list.Add(input);
            }

            return list;
        }

        private static List<Input> SplitInputStringToWords(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, @"\s+");
            return arr.Select(w => new Input(w, 1)).ToList<Input>();
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            Dictionary<string, List<Input>> map = new Dictionary<string, List<Input>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Value))
                {
                    List<Input> arr = new List<Input>();
                    arr.Add(input);
                    map.Add(input.Value, arr);
                }
                else
                {
                    map[input.Value].Add(input);
                }
            }

            return map;
        }
    }
}