/*
 * FileProcessor
 *
 * Jared Healy, All rights reserved (c) 2022
 *
 * Manages the processing of a single file
 *
 * 12/05/2022; Initial File created
 *
 */

using System.Text.RegularExpressions;

namespace markdownLang;

public class FileProcessor {
    private List<string> _lines;
    private const string MatchOnePuncMark = "(?!<[.!?])[.!?]{1}(?![.!?])";

    private static List<string> SplitAtSentence(string input) {
        List<string> ret = new();
        var matches = Regex.Matches(input, MatchOnePuncMark);
        var lastIndex = 0;
        for (var i = 0; i < matches.Count; i++) {
            var match = matches[i];
            var nextIndex = Math.Min(match.Index + 1, input.Length);
            ret.Add(input.Substring(lastIndex, nextIndex - lastIndex));
            lastIndex = nextIndex;
        }

        return ret;
    }

    public FileProcessor(string fileLocation) {
        _lines = SplitAtSentence(File.ReadAllText(fileLocation));
    }

    public List<string> Process() {
        var rules = RulesHolder.Instance.GetRules();
        var currentLines = new List<string>();
        currentLines.AddRange(_lines);
        foreach (var rule in rules) {
            currentLines = rule.Process(currentLines);
        }

        return currentLines;
    }
}