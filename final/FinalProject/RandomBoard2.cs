public class RandomBoard2 : Board2
{
    /*2D BOARD MANAGEMENT ------------------------------------------------------------
    Initiate new board
    Add* row to existing board
    Add* column to existing board
        (*) Since arrays lengths are static, the array is really
            overriden, not added to.
    
    these are private because they are only helper functions for adding words to the board
    */
    private void InitBoard()
    {
        _board = new Cell[1, 1];
        _dimY = 1;
        _dimX = 1;
    }

    private void AddBoardRows(int count, bool before)
    {
        _dimY += count;
        int indexY = 0;

        if (before) indexY = count - 1;

        Cell[,] newBoard = new Cell[_dimY, _dimX];

        //Set new board
        for (int y = indexY; y < _dimY; y++)
        {
            for (int x = 0; x < _dimX; x++)
            {
                newBoard[y, x] = _board[y, x];
            }
        }

        _board = newBoard;
    }

    private void AddBoardColumns(int count, bool before)
    {
        Cell[,] newBoard = new Cell[_dimY, _dimX];

        //Set new board
        if (before)
        {
            for (int y = 0; y < _dimY; y++)
            {
                for (int x = 0; x < _dimX; x++)
                {
                    newBoard[y, x + count] = _board[y, x];
                }
            }
        }
        else
        {
            for (int y = 0; y < _dimY; y++)
            {
                for (int x = 0; x < _dimX; x++)
                {
                    newBoard[y, x] = _board[y, x];
                }
            }
        }

        _dimX += count;
        _board = newBoard;
    }
    //END OF BOARD MANAGEMENT

    /*TERM MANAGEMENT -------------------------------------------------------------------------
    Check to see if a term can fit on the board in a certain location
    Resize the board to fit a term if needed
    Fit and Add a term to the board
    */
    private bool CheckTerm(Term term, int x, int y, bool horizontal)
    {
        string termString = term.GetTerm();
        int termLength = termString.Length;
        Cell currentCell;

        if (horizontal)
        {
            for (int yi = y; yi < y + termLength; yi++)
            {
                currentCell = GetCell(x, yi);

                if (currentCell != null)
                {
                    if (currentCell.GetContent() != $"{termString[yi - y]}") return false;
                }
            }
        }
        else
        {
            for (int xi = x; xi < x + termLength; xi++)
            {
                currentCell = GetCell(xi, y);

                if (currentCell != null)
                {
                    if (currentCell.GetContent() != $"{termString[xi - x]}") return false;
                }
            }
        }
        return true;
    }
    private void FitTerm(Term term, int x, int y, bool horizontal)
    {
        //resize board to fit word
        if (y < 0)
        {
            AddBoardRows(Math.Abs(y), true);
            y = 0;
        }
        if (x < 0)
        {
            AddBoardColumns(Math.Abs(x), true);
            x = 0;
        }

        int termLength = term.GetTerm().Length;

        if (!horizontal)
        {
            int lastY = y + termLength;
            if (lastY > _dimY) AddBoardRows(lastY - _dimY, false);
        }
        else
        {
            int lastX = x + termLength;
            if (lastX > _dimX) AddBoardColumns(lastX - _dimX, false);
        }
    }
    private List<Cell> _crossCells = new List<Cell>();

    private void AddTerm(Term term, int hintIndex, int x, int y, bool horizontal)
    {
        FitTerm(term, x, y, horizontal);

        string termString = term.GetTerm();
        int termLength = termString.Length;
        int hintIndexAlt;

        if (!horizontal)
        {
            for (int i = 0; i <= termLength; i++)
            {
                Cell existingCell = GetCell(x, y + i);
                hintIndexAlt = hintIndex;

                if (existingCell != null) hintIndexAlt = existingCell.GetHintIndex()[1];
                Cell newCell = new LetterCell($"{termString[i]}", "|", hintIndexAlt, hintIndex);
                _crossCells.Add(newCell);
                _crossCells.Remove(existingCell);
                _board[y + i, x] = newCell;
            }
        }
        else
        {
            for (int i = 0; i <= termLength; i++)
            {
                Cell existingCell = GetCell(x + i, y);
                hintIndexAlt = hintIndex;

                if (existingCell != null) hintIndexAlt = existingCell.GetHintIndex()[1];
                
                Cell newCell = new LetterCell($"{termString[i]}", "-", hintIndexAlt, hintIndex);
                _crossCells.Add(newCell);
                _crossCells.Remove(existingCell);
                _board[y, x + i] = newCell;
            }
        }
    }
    //END OF TERM MANAGEMENT

    /* PULBIC CONSTRUCTOR
    Construct a randomized board based off of a term list, count of these words to use, and allowed failed placements.

    Failed placements are the maximum allowed consecutive placement atempts allowed before aborrting construction
    */
    public RandomBoard2(List<Term> terms, int count, int allowedFails)
    {
        GenerateBoard(terms, count, allowedFails);
    }

    /* BOARD RANDOMIZER
    */
    private List<Term> _terms = new List<Term>() { };
    private Random rng = new Random();

    private void ShuffleList<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void GenerateBoard(List<Term> terms, int termCount, int allowedFails)
    {
        int fails = 0;
        int hintIndex = 1;
        List<Term> failedTerms = new List<Term>{};

        InitBoard();

        ShuffleList(terms);

        _terms.Add(terms[0]);
        AddTerm(terms[0], 0, 0, 0, true);
        terms.RemoveAt(0);

        while (_terms.Count < termCount + 1 && fails < allowedFails)
        {
            Term tempTerm = terms[0];
            terms.RemoveAt(0);

            if (terms.Count <= 0)
            {
                terms = failedTerms;
            }

            if (terms.Count == 0)
            {
                return;
            }

            string termString = tempTerm.GetTerm();
            bool succefullyPlaced = false;

            List<string> shuffledChars = new List<string> { };
            foreach (char i in termString)
            {
                shuffledChars.Add($"{i}");
            }
            ShuffleList(shuffledChars);

            foreach (string shuffledChar in shuffledChars)
            {
                int charI = termString.IndexOf(shuffledChar);

                List<Cell> tempCells = new List<Cell> { };

                foreach (Cell cell in _crossCells)
                {
                    if (cell.GetContent() == shuffledChar)
                    {
                        tempCells.Add(cell);
                    }
                }

                ShuffleList(tempCells);

                foreach (Cell cell in tempCells)
                {
                    int[] cellCoords = GetCellCoords(cell);

                    string crossType = cell.GetStringType();
                    bool termHorizontal = false;

                    switch (crossType)
                    {
                        case "-":
                            cellCoords[1] -= charI;
                            termHorizontal = false;
                            break;
                        case "|":
                            cellCoords[0] -= charI;
                            termHorizontal = true;
                            break;
                    }

                    if (CheckTerm(tempTerm, cellCoords[0], cellCoords[1], termHorizontal))
                    {
                        AddTerm(tempTerm, hintIndex, cellCoords[0], cellCoords[1], termHorizontal);
                        succefullyPlaced = true;
                        hintIndex++;
                        fails = 0;
                        break;
                    }


                }
                if (succefullyPlaced) break;
            }

            if (!succefullyPlaced)
            {
                fails++;
                failedTerms.Add(tempTerm);
            }
        }
    }
}