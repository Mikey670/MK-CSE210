public class LetterCell : Cell
{
    private string _content;
    private int _hintIndexH;
    private int _hintIndexV;

    public LetterCell(string content, string type, int hintIndex)
    {
        _content = content;
        _type = type;

        _hintIndexH = hintIndex;
        _hintIndexV = hintIndex;
    }

    public LetterCell(string content, string type, int hintIndexH, int hintIndexV)
    {
        _content = content;
        _type = type;

        _hintIndexH = hintIndexH;
        _hintIndexV = hintIndexV;
    }

    public override string GetContent() => _content;
    public override int[] GetHintIndex()
    {
        switch (_type)
        {
            case "-":
                return [_hintIndexH, _hintIndexH];
            case "|":
                return [_hintIndexV, _hintIndexV];
            case "+":
                return [_hintIndexH, _hintIndexV];
            default:
                return [-1, -1];
        }
    }
    public override void SetStringType(string type) => _type = type;

    public override void DisplayCell()
    {
        Console.Write(_content[0]);
    }

    public override void SetHintIndexH(int index) => _hintIndexH = index;
    public override void SetHintIndexV(int index) => _hintIndexV = index;
}