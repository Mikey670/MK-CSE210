/*
This is the main program. The program can load/save journals, add new entries to the journal, and print the journal.

Extra features:
-Additional commands: 
    the "help" command that will reprint the options. This removes the need for reprinting the menu every time the menu is opened.
    the "prompt" command displays the list of prompts and allows the user to modify prompts
-Prompts loaded from a seperate prompts.txt file.
-Prompts can be added/removed from the list of prompts by the user.
*/

class Program
{
    static void ShowOptions() //This funtion shows the menu options
    {
        Console.WriteLine("Menu Options:\nload - load journal from csv\nsave - save journal to csv\ncreate - create a new entry\nprint - print journal to console\nprompt - view/edit prompt list\nhelp - display option list again\nquit - close the program");
    }
    static void Main()
    {
        PromptList prompts = new PromptList(); //instantiate Promplist class
        Journal journal = new Journal(); //instantiate Journal class

        //initialize prompt values
        prompts._prompts = new List<string> {};
        prompts.LoadPrompts();

        string choice = ""; //initialize choice, used for selecting menu options
        
        ShowOptions();

        while (choice != "quit") //loops as long as the user does not quit.
        {
        //ask for and take user choice
            Console.Write("\nPick an option: ");
            choice = Console.ReadLine();
            Console.WriteLine("");

            switch (choice) //represents menu options
            {
                case "load":
                    journal.Load();
                    break;

                case "save":
                    journal.Save();
                    break;

                case "create":
                    Entry entry = new Entry();
                    entry.CreateEntry(prompts);
                    journal._entries.Add(entry);
                    break;

                case "print":
                    journal.PrintJournal();
                    break;

                case "prompt":
                    prompts.PrintPrompts();
                    Console.WriteLine("Prompt Options:\nadd - add a new prompt\nremove - remove a prompt");
                    Console.Write("Pick an option: ");
                    string choice2 = Console.ReadLine();

                    switch (choice2)
                    {
                        case "add":
                            prompts.AddPrompt();
                            break;

                        case "remove":
                            prompts.PopPrompt();
                            break;

                        case "cancel":
                            break;

                        default:
                            Console.WriteLine("Invalid option selected.");
                            break;
                    }
                    break;

                case "help": //Menu options are only printed once, the user can use this choice to print them again.
                    ShowOptions();
                    break;
                
                case "quit":
                    break;
                
                default: //exception for invalid choices
                    Console.WriteLine($"\"{choice}\" is not a valid option, try again. Type \"help\" to see menu options again.");
                    break;
            }
        }
    }
}