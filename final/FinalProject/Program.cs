class Program
{


    public static void Main(string[] args)
    {
        List<Term> testTerms = new List<Term>
        {
            new Term("hamburger", "Favorite american food named after German town."),
            new Term("pizza", "A cheesy triangle with peparoni"),
            new Term("zebra", "A striped equine"),
            new Term("apple", "A red fruit"),
            new Term("banana", "A yellow fruit"),
            new Term("sausage", "Ground meat stuffed into intestines"),
            new Term("capilary", "Responsible for bruising"),
            new Term("anteater", "Eats ants"),
            new Term("sandwich", "has little to do with sand or witches"),
            new Term("groundhog", "Bill Murrey's favorite day"),
            new Term("monday", "Garfield's favorite day"),
            new Term("testtube", "he's a _____ baby with lizard DNA, born in the basement of the CIA"),
            new Term("sauce", "Sometimes made with apples"),
            new Term("frisbee", "A throwing and catching disk"),
            new Term("discus", "A throwing and get out of the way disk"),
        };

        RandomBoard board = new RandomBoard(testTerms, 10);

        board.Print();
    }

}