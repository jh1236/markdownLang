/*
 * Program.cs
 *
 * Jared Healy, All rights reserved (c) 2022
 *
 * Jared's latest pet project, trying to make a cute markdown lang for my uni shit
 *
 * 12/05/2022; Initial File created
 *
 */

namespace markdownLang;

class PrintRule : Rule {
    public override List<string> Process(List<string> lines) {
        lines.ForEach(Console.WriteLine);
        return lines;
    }
}

class MainClass {
    public static void Main(String[] args) {
        RulesHolder.Instance.AddRule(new PrintRule());
        new FileProcessor("G:/Programming/c#/markdownLang/markdownLang/test.txt").Process();
    }
}