using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class RandomBoard : Board
{
    public RandomBoard(Random rng, List<Term> terms, int termCount, int allowedFailures)
    {
        CreateBoard(rng, terms, termCount, allowedFailures);
    }

    private List<Cell> CrossCells = new List<Cell>();

    private void CreateBoard(Random rng, List<Term> terms, int termCount, int allowedFailures)
    {
        _cells = new List<List<Cell>>(1) {new List<Cell>(1) {new Cell()}};
        _terms = new List<Term>();
        int failures = 0;

        //select terms
        for (int i = 0; i < termCount; i++)
        {
            Term tempTerm = terms[rng.Next(terms.Count())];
            _terms.Add(tempTerm);
            terms.Remove(tempTerm);
        }

        List<Term> unplacedTerms = _terms;

        Term firstTerm = unplacedTerms[rng.Next(unplacedTerms.Count)];
        AddTerm(firstTerm, true, 0, 0);
        unplacedTerms.Remove(firstTerm);

        List<Term> uncheckedTerms = unplacedTerms;

        while (unplacedTerms.Count > 0 && failures < allowedFailures)
        {
            if (failures >= allowedFailures)
            {
                Console.WriteLine("WARNING: Max faliure limit met");
            }

            bool success = false;
            if (uncheckedTerms.Count == 0) uncheckedTerms = unplacedTerms;
            //select random term
            Term term = uncheckedTerms[rng.Next(uncheckedTerms.Count)];
            uncheckedTerms.Remove(term);

            List<int> indexesToSearch = new List<int>();

            for (int i = 0; i < term.GetTerm().Length; i++)
            {
                indexesToSearch.Add(i);
            }

            //Get random term index
            while (indexesToSearch.Count > 0)
            {
                int letterIndex = indexesToSearch[rng.Next(indexesToSearch.Count)];
                indexesToSearch.Remove(letterIndex);

                List<Cell> cellsToSearch = new List<Cell>();

                foreach (Cell c in CrossCells)
                {
                    if (c.GetContent() == $"{term.GetTerm()[letterIndex]}") cellsToSearch.Add(c);
                }

                while (cellsToSearch.Count > 0)
                {
                    Cell cell = cellsToSearch[rng.Next(cellsToSearch.Count)];
                    cellsToSearch.Remove(cell);

                    int[] termCoords = GetStartCoords(letterIndex, cell);

                    if (cell.GetStringType() == "-")
                    {
                        if (AddTerm(term, true, termCoords[0], termCoords[1]))
                        {
                            unplacedTerms.Remove(term);
                            success = true;
                            break;
                        }
                    }
                }
                if (success)
                {
                    break;
                }
            }
            if (!success)
            {
                failures++;
            }
        }
    }

    private int[] LookupCellCoords(Cell cell)
    {
        for (int x = 0; x < GetDimentionX(); x++)
        {
            for (int y = 0; y < GetDimentionY(); y++)
            {
                if (_cells[y][x] == cell) return [x, y];
            }
        }
        return null;
    }

    private int[] GetStartCoords(int crossIndex, Cell crossCell)
    {
        int[] cellCoords = LookupCellCoords(crossCell);

        switch (crossCell.GetStringType())
        {
            case "-":
                while (crossIndex > 0)
                {
                    crossIndex--;
                    cellCoords[0]--;
                }
                break;
            case "|":
                while (crossIndex > 0)
                {
                    crossIndex--;
                    cellCoords[1]--;
                }
                break;
        }

        return cellCoords;
    }
    private bool CheckPlacement(Term term, bool horizontal, int x, int y)
    {
        if (horizontal)
        {
            for (int i = 0; i < term.GetTerm().Length; i++)
            {
                if (x < 0) x++;
                else if (x >= GetDimentionX()) return true;
                else if (GetCell(x, y).GetContent() != $"{term.GetTerm()[i]}") return false;
            }
        }
        else
        {
            for (int i = 0; i < term.GetTerm().Length; i++)
            {
                if (y < 0) y++;
                else if (y > GetDimentionY()) return true;
                else if (GetCell(x, y).GetContent() != $"{term.GetTerm()[i]}") return false;
            }
        }
        return true;
    }

    private bool AddTerm(Term term, bool horizontal, int x, int y)
    {
        if (!CheckPlacement(term, horizontal, x, y)) return false;

        //If coord is out of bounds, add rows/columns accordingly
        if (y < 0)
        {
            for (int i = 0; i > y; i--)
            {
                AddRow(true);
            }

            y = 0;
        }
        else if (y > GetDimentionY())
        {
            for (int i = 0; i < GetDimentionY() - y; i++)
            {
                AddRow(false);
            }
        }

        if (x < 0)
        {
            for (int i = 0; i > x; i--)
            {
                AddColumn(true);
            }

            x = 0;
        }
        else if (x > GetDimentionX())
        {
            for (int i = 0; i < GetDimentionX() - x; i++)
            {
                AddColumn(false);
            }
        }

        //Add cells
        if (horizontal)
        {
            foreach (char c in term.GetTerm())
            {
                if (x > GetDimentionX())
                {
                    AddColumn(false);
                }

                if (GetCell(x, y).GetStringType() == "n")
                {
                    LetterCell tempCell = new LetterCell($"{c}", "-", _terms.IndexOf(term));
                    SetCell(x, y, tempCell);
                    CrossCells.Add(tempCell);
                }
                else
                {
                    GetCell(x, y).SetStringType("+");
                    GetCell(x, y).SetHintIndexH(_terms.IndexOf(term));
                    CrossCells.Remove(GetCell(x, y));
                }

                x++;
            }
        }
        else
        {
            foreach (char c in term.GetTerm())
            {
                if (y > GetDimentionY())
                {
                    AddRow(false);
                }

                if (GetCell(x, y).GetStringType() == "n")
                {
                    LetterCell tempCell = new LetterCell($"{c}", "|", _terms.IndexOf(term));
                    SetCell(x, y, tempCell);
                }
                else
                {
                    GetCell(x, y).SetStringType("+");
                    GetCell(x, y).SetHintIndexV(_terms.IndexOf(term));
                }

                y++;
            }
        }
        return true;
    }

    private void AddRow(bool before)
    {
        List<Cell> newRow = new List<Cell>() { };
        for (int i = 0; i < GetDimentionX(); i++)
        {
            newRow.Add(new Cell());
        }

        if (before)
        {
            _cells.Insert(0, newRow);
        }
        else
        {
            _cells.Add(newRow);
        }

        AddDimentionY(1);
    }

    private void AddColumn(bool before)
    {
        if (before)
        {
            foreach (List<Cell> list in _cells)
            {
                list.Insert(0, new Cell());
            }
        }
        else
        {
            foreach (List<Cell> list in _cells)
            {
                list.Add(new Cell());
            }
        }

        AddDimentionX(1);
    }
}