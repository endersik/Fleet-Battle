using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet_Battle
{
    public class UI
    {
        public static void MarkShipWithGreen(string text){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.Blue;
        }
        public static void MarkHitWithRed(string text){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.Blue;
        }

        public static void MarkMissWithWhite(string text){
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.Blue;
        }
    }
}