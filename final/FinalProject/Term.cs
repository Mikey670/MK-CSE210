public class Term
{
    private string _term;
    private string _hint;

    public Term(string term, string hint)
    {
        _term = term;
        _hint = hint;
    }

    public string GetTerm() => _term;
    public string GetHint() => _hint;
}