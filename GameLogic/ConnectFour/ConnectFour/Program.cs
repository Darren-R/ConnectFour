using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Game
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start Menu");
            Console.WriteLine("1: Play with humans");
            Console.WriteLine("2: Play with AI");
            Console.WriteLine("3: Load previous game");
            Console.WriteLine("4: Quit\n");

            int choice = UserChoice.NumberRequested("Menu Choice");
            switch (choice)
            {
                case 1:
                    Game newGame = new Game("X", "O", false);
                    newGame.startGame();
                    break;
                case 2:
                    Game aiGame = new Game("X", "O", true);
                    aiGame.startGame();
                    break;
                case 3:
                    
                    Game savedGame = new Game("X", "O", false);
                    savedGame = SaveOrLoad.loadGame() as Game;
                    savedGame.startGame(); 
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}