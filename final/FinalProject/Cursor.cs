public class Cursor(int x, int y, int maxX, int maxY, int minX, int minY)
{
    private int _x = x;
    private int _y = y;

    private int _maxX = maxX;
    private int _maxY = maxY;
    private int _minX = minX;
    private int _minY = minY;

    public int GetX() => _x;
    public int GetY() => _y;

    public void setPosition(int x, int y)
    {
        if ((x >= _minX || x <= _maxX) && (y >= _minY || y <= _maxY))
        {
            _x = x;
            _y = y;
        }
    }

    public void Move(bool horizontal, int distance)
    {
        if (horizontal)
        {
            _x = int.Max(_minX, int.Min(_maxX, _x + distance));
        }    
        else _y = int.Max(_minY, int.Min(_maxY, _y + distance));
    }

    public string TakeInput()
    {
        int key = (int)Console.ReadKey(true).Key;

        switch (key)
        {
            //left
            case 37:
                Move(true, -1);
                return null;

            //up
            case 38:
                Move(false, -1);
                return null;

            //right
            case 39:
                Move(true, 1);
                return null;

            //down
            case 40:
                Move(false, 1);
                return null;

            //letters
            default:
                string sOut = null;
                if ((key >= 65 && key <= 90) || key == 27)
                {
                    sOut = $"{(char)key}".ToLower();
                }
                return sOut;
        }
    }
}