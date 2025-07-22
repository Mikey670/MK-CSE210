public class RandomBoard : Board
{
    private List<Term> _terms = new List<Term>();
    private List<Cell> _crossCells = new List<Cell>();
    private static Random _rng = new Random();

    private bool TryAddTerm(Term term, int x, int y, bool horizontal)
    {
        int xI = x;
        int yI = y;

        List<Cell> termCells = term.GetCells(horizontal);

        if (horizontal)
        {
            if (GetCell(x - 1, y) != null) return false;
            if (GetCell(x - 1, y + 1) != null) return false;
            if (GetCell(x - 1, y - 1) != null) return false;
            if (GetCell(x + termCells.Count + 1, y) != null) return false;
            if (GetCell(x + termCells.Count + 1, y + 1) != null) return false;
            if (GetCell(x + termCells.Count + 1, y - 1) != null) return false;
        }
        else
        {
            if (GetCell(x, y - 1) != null) return false;
            if (GetCell(x + 1, y - 1) != null) return false;
            if (GetCell(x - 1, y - 1) != null) return false;
            if (GetCell(x, y + termCells.Count + 1) != null) return false;
            if (GetCell(x + 1, y + termCells.Count + 1) != null) return false;
            if (GetCell(x - 1, y + termCells.Count + 1) != null) return false;
        }

        foreach (Cell cell in termCells)
        {
            Cell existingCell = GetCell(x, y);

            if (existingCell != null)
            {
                if (existingCell.GetContent() != cell.GetContent()) return false;
            }
            else
            {
                if (horizontal)
                {
                    if (GetCell(x, y + 1) != null) return false;
                    if (GetCell(x, y - 1) != null) return false;
                }
                else
                {
                    if (GetCell(x + 1, y) != null) return false;
                    if (GetCell(x - 1, y) != null) return false;
                }
            }

            if (horizontal) x++;
            else y++;
        }

        x = xI;
        y = yI;

        bool lastWasCross = false;

        for (int i = 0; i < termCells.Count; i++)
        {
            Cell existingCell = GetCell(x, y);

            if (existingCell != null)
            {
                existingCell.SetAlternateHint(termCells[i].GetHint());
                _crossCells.Remove(existingCell);
                try { _crossCells.Remove(GetCell(x - 1, y)); } catch { }
                try { _crossCells.Remove(GetCell(x + 1, y)); } catch { }
                try { _crossCells.Remove(GetCell(x, y - 1)); } catch { }
                try { _crossCells.Remove(GetCell(x, y + 1)); } catch { }

                lastWasCross = true;
            }
            else
            {
                if (!lastWasCross) _crossCells.Add(termCells[i]);
                else lastWasCross = false;

                SetCell(termCells[i], x, y);
            }

            if (horizontal) x++;
            else y++;
        }

        _terms.Add(term);
        return true;
    }

    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = _rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public RandomBoard(List<Term> terms, int count)
    {
        int termsChecked = 0;
        int crossesChecked = 0;
        int cellsCompared = 0;
        Term firstTerm = terms[_rng.Next(0, terms.Count)];
        terms.Remove(firstTerm);

        TryAddTerm(firstTerm, 0, 0, true);

        bool placed = true;

        while (_terms.Count < count && placed)
        {
            placed = false;

            List<Cell> crossesToCheck = _crossCells;
            Shuffle(crossesToCheck);

            List<Term> termsToCheck = terms;
            Shuffle(termsToCheck);

            foreach (Cell cross in crossesToCheck)
            {
                crossesChecked++;
                foreach (Term term in termsToCheck)
                {
                    termsChecked++;
                    List<Cell> termCells = term.GetCells(!cross.GetHorizontal());
                    List<Cell> scrambledCells = termCells;
                    Shuffle(scrambledCells);

                    foreach (Cell cell in scrambledCells)
                    {
                        cellsCompared++;
                        if (cell.GetContent() == cross.GetContent())
                        {
                            int termCellIndex = termCells.IndexOf(cell);

                            int x = cross.GetX();
                            int y = cross.GetY();

                            if (!cross.GetHorizontal())
                            {
                                x -= termCellIndex;
                            }
                            else
                            {
                                y -= termCellIndex;
                            }

                            if (TryAddTerm(term, x, y, !cross.GetHorizontal()))
                            {
                                placed = true;
                                terms.Remove(term);
                                break;
                            }
                        }
                    }
                    if (placed) break;
                }
                if (placed) break;
            }
        }

        Console.WriteLine("crosses scanned " + crossesChecked);
        Console.WriteLine("terms scanned " + termsChecked);
        Console.WriteLine("cells compared " + cellsCompared);
    }
}