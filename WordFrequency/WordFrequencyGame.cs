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
            // NOTE: LINQ
            var wordCounts = new Regex(@"\s+").Split(inputStr)
                          .GroupBy(w => w)
                          .Select(g => new { Word = g.Key, Count = g.Count() })
                          .OrderByDescending(x => x.Count);

            return string.Join("\n", wordCounts.Select(x => $"{x.Word} {x.Count}"));
        }
    }
}
