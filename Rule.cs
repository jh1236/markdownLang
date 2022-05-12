namespace markdownLang;

public abstract class Rule {
    public abstract List<string> Process(List<string> lines);
}