public class Board()
{
    public struct Coordinate(int x, int y)
    {
        public int _x = x;
        public int _y = y;
    }

    protected Dictionary<Coordinate, Cell> _content = new Dictionary<Coordinate, Cell>();

    protected int _minX = int.MaxValue;
    protected int _maxX = int.MinValue;
    protected int _minY = int.MaxValue;
    protected int _maxY = int.MinValue;

    public Dictionary<Coordinate, Cell> GetContent() => _content;
    public int GetMinX() => _minX;
    public int GetMaxX() => _maxX;
    public int GetMinY() => _minY;
    public int GetMaxY() => _maxY;
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

    public static bool Compare(Board board1, Board board2)
    {
        for (int y = board1._minY; y <= board1._maxY; y++)
        {
            for (int x = board1._minX; x <= board1._maxX; x++)
            {
                Cell cell1;
                Cell cell2;

                if (board1._content.TryGetValue(new Coordinate(x, y), out cell1))
                {
                    if (board2._content.TryGetValue(new Coordinate(x, y), out cell2))
                    {
                        if (cell1.GetContent() != cell2.GetContent()) return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (board2._content.TryGetValue(new Coordinate(x, y), out _))
                {
                    return false;
                }
            }
        }
        return true;
    }
}