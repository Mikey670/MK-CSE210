public class Board()
{
    struct Coordinate(int x, int y)
    {
        public int _x = x;
        public int _y = y;
    }

    private Dictionary<Coordinate, Cell> _content = new Dictionary<Coordinate, Cell>();

    private int _minX = int.MaxValue;
    private int _maxX = int.MinValue;
    private int _minY = int.MaxValue;
    private int _maxY = int.MinValue;

    public void SetCell(Cell cell, int x, int y)
    {
        //SET NEW BOUNDS
        if (x > _maxX) _maxX = x;
        if (x < _minX) _minX = x;
        if (y > _maxY) _maxY = y;
        if (y < _minY) _minY = y;

        //ADD CELL TO CONTENT
        cell.SetCoordinates(x, y);
        _content[new Coordinate(x, y)] = cell;
    }

    public Cell GetCell(int x, int y)
    {
        Cell cell;

        if (_content.TryGetValue(new Coordinate(x, y), out cell))
        {
            return cell;
        }
        else return null;        
    }

    public virtual void Print()
    {
        for (int y = _minY; y <= _maxY; y++)
        {
            for (int x = _minX; x <= _maxX; x++)
            {
                Cell cell;

                if (_content.TryGetValue(new Coordinate(x, y), out cell))
                {
                    Console.Write(cell.GetContent() + " ");
                }
                else Console.Write("  ");
            }
            Console.WriteLine();
        }
    }
}