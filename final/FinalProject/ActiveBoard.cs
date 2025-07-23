public class ActiveBoard : Board
{
    private Cursor _cursor;
    private Board _derivedBoard;

    public ActiveBoard(Board dirivedBoard)
    {
        _derivedBoard = dirivedBoard;
        _content = new Dictionary<Coordinate, Cell>();
        _maxX = dirivedBoard.GetMaxX();
        _minX = dirivedBoard.GetMinX();
        _maxY = dirivedBoard.GetMaxY();
        _minY = dirivedBoard.GetMinY();

        _cursor = new Cursor(0, 0, _maxX, _maxY, _minX, _minY);

        for (int y = _minY; y <= _maxY; y++)
        {
            for (int x = _minX; x <= _maxX; x++)
            {
                Cell cell;

                if (dirivedBoard.GetContent().TryGetValue(new Coordinate(x, y), out cell))
                {
                    Cell newCell;

                    newCell = new Cell("#", cell.GetHorizontal(), cell.GetHint());
                    newCell.SetAlternateHint(cell.GetAlternateHint());

                    SetCell(newCell, x, y);
                }
            }
        }
    }
    public override void Print()
    {
        //Uncomment this \/
        Console.Clear();

        for (int y = _minY; y <= _maxY; y++)
        {
            for (int x = _minX; x <= _maxX; x++)
            {
                Cell cell;

                if (_content.TryGetValue(new Coordinate(x, y), out cell))
                {
                    if (x == _cursor.GetX() && y == _cursor.GetY())
                    {
                        Console.Write(cell.GetContent().ToUpper() + "<");
                    }
                    else if (x == _cursor.GetX() - 1 && y == _cursor.GetY())
                    {
                        Console.Write(cell.GetContent() + ">");
                    }
                    else
                    {
                        Console.Write(cell.GetContent() + " ");
                    }
                }
                else
                {
                    if (x == _cursor.GetX() && y == _cursor.GetY())
                    {
                        Console.Write(" <");
                    }
                    else if (x == _cursor.GetX() - 1 && y == _cursor.GetY())
                    {
                        Console.Write(" >");
                    }
                    else Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
        Cell tempCell = GetCell(_cursor.GetX(), _cursor.GetY());
        if (tempCell != null)
        {
            Console.WriteLine("HINTS");
            tempCell.PrintHints();
        }
        Console.WriteLine("\nUse arrow keys to move cursor (> <) || Press letter key to replace selected letter || press esc to abort");
    }

    public void RunBoard()
    {
        DateTime startTime = DateTime.Now;

        while (!Compare(_derivedBoard, this))
        {
            Print();

            string letter = _cursor.TakeInput();

            if (letter != null)
            {
                if (letter == $"{(char)27}")
                {
                    Console.WriteLine("You gave up! :( press any key to continue.");
                    Console.ReadKey(true);
                    return;
                }

                Cell cell;

                if (_content.TryGetValue(new Coordinate(_cursor.GetX(), _cursor.GetY()), out cell))
                {
                    cell.SetContent(letter);
                }
            }
        }
        Console.Clear();
        _derivedBoard.Print();

        TimeSpan timeSpan = DateTime.Now - startTime;
        Console.WriteLine($"You completed the puzzle in {(int)timeSpan.TotalMinutes}:{timeSpan.Seconds}! Good Job!\nPress any key to continue.");
        Console.ReadKey(true);
    }
}