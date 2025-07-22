public class Term(string term, string hint)
{
    private string _term = term;
    private string _hint = hint;

    public string GetTerm() => _term;
    public List<Cell> GetCells(bool horizontal)
    {
        List<Cell> cells = new List<Cell>();

        foreach (char c in _term)
        {
            Cell cell = new Cell($"{c}", horizontal, _hint);
            cells.Add(cell);
        }

        return cells;
    }
    public string GetHint() => _hint;
}