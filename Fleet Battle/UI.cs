using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet_Battle
{
    public class UI
    {
        public static void Welcome(){
            Console.Clear();
            PrintDarkYellow("Ahoy, Captain! The seas churn for battle! Plot your course and deploy your fleet!");
            PressEnterToContinue();
        }
        public static string GetPlayerName(){
            Console.Write("Enter player name: ");
            return Console.ReadLine();
        }
        public static void AnnounceBattleStarts(){
            PrintDarkYellow("Brace yourself, Captain! The enemy fleet approaches! Time to unleash your naval fury!");
            PressEnterToContinue();
        }
        public static void AnnounceWinner(string name){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{name} won the game!");
            Console.ForegroundColor= ConsoleColor.White;
        }



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
        public static void PrintRed(string text){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.White;
        }
        public static void PrintDarkYellow(string text){
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
        public static void PressEnterToContinue(){
            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        

        
    }
}