using System;

namespace DevCampApplication
{
    public static class MainClass
    {
        private static string option;

        static void Main(string[] args)
        {
            do
            {
                new Message().Print();

                Console.WriteLine("Do you want to try again (yes/no)? ");
                option = Console.ReadLine().ToLower();
            }
            while (option == "yes");
        }
    }
}
