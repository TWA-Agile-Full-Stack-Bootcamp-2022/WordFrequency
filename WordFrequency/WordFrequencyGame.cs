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

            var arr = Regex.Split(inputStr, @"\s+");

            var inputList = GetInputList(arr);

            var map = GroupByInputValue(inputList);

            var noDuplicateInputList = NoDuplicateInputList(map);

            return string.Join("\n", FormatOutput(noDuplicateInputList).ToArray());
        }

        private static List<Input> NoDuplicateInputList(Dictionary<string, List<Input>> map)
        {
            var noDuplicateInputList = map.Select(entry => new Input(entry.Key, entry.Value.Count)).ToList();

            noDuplicateInputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);
            return noDuplicateInputList;
        }

        private static List<string> FormatOutput(List<Input> noDuplicateInputList)
        {
            return noDuplicateInputList.Select(w => w.Value + " " + w.WordCount).ToList();
        }

        private static List<Input> GetInputList(string[] arr)
        {
            return arr.Select(s => new Input(s, 1)).ToList();
        }

        private Dictionary<string, List<Input>> GroupByInputValue(List<Input> inputList)
        {
            var map = new Dictionary<string, List<Input>>();
            foreach (var input in inputList)
            {
                if (!map.ContainsKey(input.Value))
                {
                    var arr = new List<Input> { input };
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
