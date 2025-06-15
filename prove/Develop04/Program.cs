using System;

class Program
{

    static void Main(string[] args)
    {
        int DisplayOptions()
        {
            Console.Write("Menu Options:\n    1. Start breathing activity\n    2. Start reflection activity\n    3.Start listing activity\n    4. Quit\nSelect a choice from the menu> ");
            return int.Parse(Console.ReadLine());
        }

        BreathingActivity a0 = new BreathingActivity("Guided Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
            , 30, 6, 4);
        ReflectionActivity a1 = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
            , 30, new string[] { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." }
            , new string[] { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" });
        ListingActivity a2 = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
            , 30, new string[] { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" });

        int option = 0;

        while (option != 4)
        {
            option = DisplayOptions();
            switch (option)
            {
                case 1:
                    a0.RunActivity();
                    break;
                case 2:
                    a1.RunActivity();
                    break;
                case 3:
                    a2.RunActivity();
                    break;
                case 4:
                    Console.WriteLine("Thanks! Have a good day!");
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}