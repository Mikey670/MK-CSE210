using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public abstract class Board2
{
    // 2D array management
    // [y,x]
    protected Cell[,] _board;
    protected int _dimY = 0;
    protected int _dimX = 0;

    public void SetCell(Cell cell, int x, int y)
    {
        try
        {
            _board[y, x] = cell;
        }
        catch (Exception)
        {
            Console.WriteLine("ERROR: coordinate is out of board range");
        }
    }

    public Cell GetCell(int x, int y)
    {
        try
        {
            return _board[y, x];
        }
        catch (Exception)
        {
            Console.WriteLine();
            return null;
        }
    }

    public int[] GetCellCoords(Cell cell)
    {
        for (int y = 0; y < _dimY; y++)
        {
            for (int x = 0; x < _dimX; x++)
            {
                Cell cCell = GetCell(x, x);
                if (cCell == cell)
                {
                    return [x, y];
                }
            }
        }
        return null;
    }

    public void DisplayBoard()
    {
        for (int y = 0; y < _dimY; y++)
        {
            for (int x = 0; x < _dimX; x++)
            {
                Cell tempCell = GetCell(x, y);

                if (tempCell != null)
                {
                    tempCell.DisplayCell();
                }
            }
        }
    }
}