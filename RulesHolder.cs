namespace markdownLang; 

public class RulesHolder {
    public static readonly RulesHolder Instance = new();
    private RulesHolder(){}

    private List<Rule> rules = new();

    public void AddRule(Rule rule) {
        rules.Add(rule);
    }

    public Rule[] GetRules() {
        return rules.ToArray();
    }
}