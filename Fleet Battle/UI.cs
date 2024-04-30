using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet_Battle
{
    public class UI
    {
        public static void MarkOceanWithBlue(string text){
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.White;
        }
        public static void MarkShipWithGreen(string text){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.White;
        }
        public static void MarkHitWithRed(string text){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.White;
        }

        public static void PrintDotAnimation(int timer = 10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.Clear();
        }

        public static string GetUserName(){
            Console.Write("Enter user name: ");
            return Console.ReadLine();
        }
        public static void Welcome(string playerName){
            Console.Clear();
            Console.Write($"Welcome {playerName}! Let's place your ships...");
            PressEnterToContinue();
        }

        public static void PressEnterToContinue(){
            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        public static void PrintRed(string text){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.White;
        }

        public static void AnnounceWinner(string name){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{name} won the game!");
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}