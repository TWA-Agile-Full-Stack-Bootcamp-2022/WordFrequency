﻿using System;
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

            List<string> strList = words.Select(w => w.Value + " " + w.WordCount).ToList();

            return string.Join("\n", strList.ToArray());
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