using PokerGame.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PokerGame
{
    class Program
    {
        private const int NumberOfPlayers = 2;
        private const int NumberOfCardsPerPerson = 5;
        static void Main(string[] args)
        {
            if (args != null &&  args.Length == 0)
            {
                Console.WriteLine("Please provide a file with cards as a parameter.");
                return;
            }
            if (File.Exists(args[0]))
            {
                SetupGame(args[0]);
            }
            else
            {
                Console.WriteLine("The file does not exist");
            }
        }

        public static void SetupGame(string file)
        {
            var completeInput = new List<string>();

            try
            {
                //Read file and add all hands to a list for processing
                using (var sr = new StreamReader(file))
                {
                    string input = string.Empty;
                    while ((input = sr.ReadLine()) != null)
                    {
                        completeInput.Add(input);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var result = PokerService.Process(completeInput);

            Console.WriteLine($"Player1: {result.ScorePlayer1}");
            Console.WriteLine($"Player2: {result.ScorePlayer2}");

            if (result.Errors.Any())
            {
                foreach (var line in result.Errors)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey();
        }
    }
}
