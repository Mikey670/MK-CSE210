using System;

class Program
{
    static void Main(string[] args)
    {
        List<Term> testTerms = new List<Term>
        {
            new Term("orange", "An orange fruit"),
            new Term("banana", "A yellow fruit"),
            new Term("apple", "A red fruit"),
            new Term("grannysmith", "A green apple"),
            new Term("pepper", "A spicy fruit"),
            new Term("grapefruit", "An overlarge orange"),
            new Term("gumbi", "A clay man, friend of poki"),
            new Term("hogwarts", "The most popular school named after a skin afliction"),
            new Term("superman", "Jerry Sinfeild's hero"),
            new Term("monkey", "A harry tailed primate that loves bananas")
        };

        Random rng = new Random();

        RandomBoard2 testBoard = new RandomBoard2(testTerms, testTerms.Count, 100);

        testBoard.DisplayBoard();
    }
}