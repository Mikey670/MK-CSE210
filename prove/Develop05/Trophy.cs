/*
     ________
____/________\____
\___{_LVL_15_}___/
  \_\_ <  > _/_/
      \    /
       {$$}
      /____\
*/
/*
     ________\n____/________\\____\n\___{_LVL_

_}___/\n  \\_\\_ <  > _/_/\n      \\    /\n       {$$}\n      /____\\\n
*/
/*
   _________
___\LVL_10_/___
\\__\  $  /__//
 '---\___/---'
      /_\
     _{ }_

*/
/*
   _________\n___\\LVL_

_/___\n\\\\__\\  $  /__//\n '---\\___/---'\n      /_\\\n     _{ }_\n\n
*/
/*
_______
\LVL_5/
<\___/>
 _|:|_

*/
/*
_______\n\\LVL_

/\n<\\___/>\n _|:|_\n\n
*/

public class Trophy
{
    //Static ASCII trophies
    private static string[] _gold = { "     _______\n____/_______\\_____\n\\___{_LVL_", "_}___/\n  \\_\\_ <  > _/_/\n      \\    /\n       {$$}\n      /____\\" };
    private static string[] _silver = { "   _________\n___\\LVL_", "_/___\n\\\\__\\  $  /__//\n '---\\___/---'\n      /_\\\n     _{ }_\n" };
    private static string[] _bronze = { "_______\n\\LVL_", "/\n<\\___/>\n _|:|_\n" };
    private static int[] _trophyValues = {10, 50};

    private int _level;

    public Trophy(int level)
    {
        _level = level;
    }

    public void SetLevel(int level) => _level = level;
        
    public void ShowTrophy()
    {
        string levelString = $"{_level}";
        int levelLength = levelString.Length;
        int labelLength;

        if (_level >= _trophyValues[1])
        {
            labelLength = 3 - levelLength;

            Console.Write(_gold[0] + Math.Min(999, _level));
            for (int i = 0; 1 < labelLength; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine(_gold[1]);
        }
        else if (_level >= _trophyValues[0])
        {
            labelLength = 2 - levelLength;

            Console.Write(_silver[0] + Math.Min(99, _level));
            for (int i = 0; 1 < labelLength; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine(_silver[1]);
        }
        else
        {
            Console.Write(_bronze[0] + Math.Min(9, _level) + _bronze[1]);
        }
    }
}