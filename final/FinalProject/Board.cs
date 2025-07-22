public abstract class Board
{
    protected List<List<Cell>> _cells;
    protected List<Term> _terms;
    private int _dimentionX = 1;
    private int _dimentionY = 1;

    //Get/Set//
    public int GetDimentionX() => _dimentionX;
    public int GetDimentionY() => _dimentionY;
    public void AddDimentionX(int add) => _dimentionX += add;
    public void AddDimentionY(int add) => _dimentionY += add;

    public Cell GetCell(int posX, int posY) => _cells[posX][posY];

    public void SetCell(int posX, int posY, Cell cell) => _cells[posX][posY] = cell;

    //DISPLAY
    public void DisplayBoard()
    {
        foreach (var row in _cells)
        {
            Console.WriteLine();
            foreach (Cell cell in row)
            {
                Console.Write(" ");
                cell.DisplayCell();
            }
            Console.WriteLine();
        }
    }
    public void DisplayHint(string type, int h, int v)
    {
        if (h < 0 || v < 0) return;
        switch (type)
        {
            case "-":
                Console.WriteLine("Across:" + _terms[h].GetHint());
                break;
            case "|":
                Console.WriteLine("Down:" + _terms[v].GetHint());
                break;
            case "+":
                Console.WriteLine("Across:" + _terms[h].GetHint());
                Console.WriteLine("Down:" + _terms[v].GetHint());
                break;
        }
        Console.WriteLine("Down");
    }
}