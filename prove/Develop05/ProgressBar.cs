public class ProgressBar
{
    private int _maxScore;
    private int _currentScore;
    private int _displayLength;

    private string _display;

    public ProgressBar(int maxScore, int currentScore, int displayLength)
    {
        _maxScore = maxScore;
        _currentScore = currentScore;
        _displayLength = displayLength;
    }

    public void SetPoints(int points) => _currentScore = points;

    public void DisplayBar()
    {
        _display = "";
        int completedCells = _displayLength * _currentScore / _maxScore;

        for (int i = 0; i < _displayLength; i++)
        {
            if (completedCells > 0)
            {
                _display += "#";
                completedCells--;
            }
            else
            {
                _display += "-";
            }
        }

        Console.WriteLine(_display);
    }

    public void DisplayPercent()
    {
        int percent = 100 * _currentScore / _maxScore;
        Console.Write(percent + "%");
    }

    public void DisplayPoints()
    {
        Console.Write(_currentScore + "/" + _maxScore);
    }
}