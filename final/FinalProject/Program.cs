class Program
{
    /*
    "__________                    .___                                                    \n" +
    "\______   \_____    ____    __| _/____   _____         By: Michael Knight             \n" +
    "|       _/\__  \  /    \  / __ |/  _ \ /     \                                       \n" +
    "|    |   \ / __ \|   |  \/ /_/ (  <_> )  Y Y  \     Crossword Files can be found     \n" +
    "|____|_  /(____  /___|  /\____ |\____/|__|_|  /     at ./Crosswords                   \n" +
    "        \/      \/     \/      \/            \/                                       \n" +
    "                    _________                                                     .___\n" +
    "                    \_   ___ \_______  ____  ______ ________  _  _____________  __| _/\n" +
    "                    /    \  \/\_  __ \/  _ \/  ___//  ___/\ \/ \/ /  _ \_  __ \/ __ | \n" +
    "                    \     \____|  | \(  <_> )___ \ \___ \  \     (  <_> )  | \/ /_/ | \n" +
    "                    \______  /|__|   \____/____  >____  >  \/\_/ \____/|__|  \____ | \n" +
    "                            \/                  \/     \/                          \/ \n" +
    "________                                   __                                       \n" + 
    "/  _____/  ____   ____   ________________ _/  |_  ___________                        \n" +
    "/   \  ____/ __ \ /    \_/ __ \_  __ \__  \\   __\/  _ \_  __ \                       \n" +
    "\    \_\  \  ___/|   |  \  ___/|  | \// __ \|  | (  <_> )  | \/                       \n" +
    "\______  /\___  >___|  /\___  >__|  (____  /__|  \____/|__|                          \n" +
    "        \/     \/     \/     \/           \/                                          \n" +
    "What do you want to do?"
    */
    private static List<Puzzle> puzzles;
    private static Menu puzzleMenu;

    private static RandomBoard randomBoard;
    private static ActiveBoard activeBoard;

    private static Menu mainMenu = new(
        (
            @" __________                    .___                                                    " + "\n" +
            @" \______   \_____    ____    __| _/____   _____         By: Michael Knight             " +"\n" +
            @" |       _/\__  \  /    \  / __ |/  _ \ /     \                                       " +"\n" +
            @" |    |   \ / __ \|   |  \/ /_/ (  <_> )  Y Y  \     Crossword Files can be found     " +"\n" +
            @" |____|_  /(____  /___|  /\____ |\____/|__|_|  /     at ./Crosswords                   " +"\n" +
            @"        \/      \/     \/      \/            \/                                       " +"\n" +
            @"                    _________                                                     .___" +"\n" +
            @"                    \_   ___ \_______  ____  ______ ________  _  _____________  __| _/" +"\n" +
            @"                    /    \  \/\_  __ \/  _ \/  ___//  ___/\ \/ \/ /  _ \_  __ \/ __ | " +"\n" +
            @"                    \     \____|  | \(  <_> )___ \ \___ \  \     (  <_> )  | \/ /_/ | " +"\n" +
            @"                     \______  /|__|   \____/____  >____  >  \/\_/ \____/|__|  \____ | " +"\n" +
            @"                            \/                  \/     \/                          \/ " +"\n" +
            @"  ________                                   __                                       " + "\n" +
            @" /  _____/  ____   ____   ________________ _/  |_  ___________                        " +"\n" +
            @"/   \  ____/ __ \ /    \_/ __ \_  __ \__  \\   __\/  _ \_  __ \                       " +"\n" +
            @"\    \_\  \  ___/|   |  \  ___/|  | \// __ \|  | (  <_> )  | \/                       " +"\n" +
            @" \______  /\___  >___|  /\___  >__|  (____  /__|  \____/|__|                          " +"\n" +
            @"        \/     \/     \/     \/           \/                                          " +"\n" +
            "What do you want to do?"
        ),
        new List<string>
        {
            "Select Puzzle",
            "Reload Puzzle Files",
            "Quit"
        }
    );

    private static Menu sizeMenu = new("Select Puzzle Size", new List<string>
        {
            "Small (~15 words)",
            "Medium (~30)",
            "Large (~50)",
            "Huge (~100)",
            "Go Back"
        }
    );

    public static void Main(string[] args)
    {
        Reload();

        int choice;

        while ((choice = mainMenu.GetChoice()) != 2)
        {
            if (choice == 0)
            {
                int puzzleChoice = puzzleMenu.GetChoice();

                if (puzzleChoice != puzzleMenu.GetLength() - 1)
                {
                    int sizeChoice = sizeMenu.GetChoice();

                    if (sizeChoice != 4)
                    {
                        int size = 0;

                        switch (sizeChoice)
                        {
                            case 0: size = 15; break;
                            case 1: size = 30; break;
                            case 2: size = 50; break;
                            case 3: size = 100; break;
                        }

                        randomBoard = new(puzzles[puzzleChoice].GetTerms(), size);
                        activeBoard = new(randomBoard);

                        activeBoard.RunBoard();
                    }
                }
            }
            else if (choice == 1)
            {
                Reload();

                Console.WriteLine("Files Reloaded. Press any key to continue!");
                Console.ReadKey(true);
            }
        }

        void Reload()
        {
            puzzles = LoadPuzzleFiles("./Crosswords");
            List<string> puzzleOptions = [];

            foreach (Puzzle puzzle in puzzles) puzzleOptions.Add(puzzle.GetTitle());
            puzzleOptions.Add("Back");
            puzzleMenu = new("Select A Puzzle", puzzleOptions);
        }
    }



    struct Puzzle(string title, List<Term> terms)
    {
        private string _title = title;
        private List<Term> _terms = terms;

        public string GetTitle() => _title;
        public List<Term> GetTerms() => _terms;
    }

    static List<Puzzle> LoadPuzzleFiles(string directory)
    {
        string[] files = Directory.GetFiles(directory);
        List<Puzzle> puzzles = [];
        List<Term> masterTerms = [];

        foreach (string file in files)
        {
            List<Term> terms = [];
            StreamReader sr = new(file);

            string name = sr.ReadLine();

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] splitLine = line.Split(",");
                Term term = new(splitLine[0], splitLine[1]);

                terms.Add(term);
                masterTerms.Add(term);
            }

            puzzles.Add(new(name, terms));
        }

        puzzles.Insert(0, new("Omni Puzzle", masterTerms));
        return puzzles;
    }
}