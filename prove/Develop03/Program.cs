/*
Michael Knight

Scripture Memorizer
    This program displays Heleman 5:12, and allows the user to hide words from it by hitting enter or typing the number of words they want to hide.
    The user can type "quit" to close the program at any time. The program will close when all of the words in the scripture have been hidden.

    Each class has constructors: 
    -Scripture class has two, one for a single-verse scripture, another for a multi-verse scripture
    -Reference class has two
    -Word class has one

Additional features:
    Scripture.HideWords(int) will hide the exact number of words, skipping words that are already hidden.

    Scripture.HideWords(int) accepts an integer value. Using int.TryParse(), The user input system can accept integers and will pass them to the hide function.
    If a non-integer value is typed, it will instead hide one word.

    Word class has a bool that sets its hidden state. Word retains the text of the word even after the word is hidden. 

    *{unimplemented, this is just an idea.}
    After all of the words are hidden, the user is asked
    to type the hidden words one-by one, each one being revealed as they are typed correctly. The user is allowed 3 failed attempts before they lose.
*/
class Program
{
    static void Main()
    {
        string choice = "";

        Scripture scripture = new Scripture("And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.",
        "Helaman", 5, 12);

        while (choice != "quit" && !scripture.CheckHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.Write("\nType the number of words you would like to remove || type \"quit\" to leave\n>>> ");
            choice = Console.ReadLine();

            if (choice != "quit")
            {
                int wordsToHide;

                if (int.TryParse(choice, out wordsToHide))
                {
                    scripture.HideWords(wordsToHide);
                }
                else
                {
                    scripture.HideWords(1);
                }
            }
        }
        Console.Clear();
        Console.WriteLine("Thanks for using Scripture Memorizer!");
    }
}