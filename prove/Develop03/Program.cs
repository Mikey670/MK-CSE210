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
    }
}