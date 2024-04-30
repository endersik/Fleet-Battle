using System;
using Fleet_Battle;

namespace FleetBattle
{
    
    internal class Program
    {
        
        public static void Attack(string playerName, GameMap enemyMap){
            Console.Clear();
            bool showShips = false;
            Console.WriteLine($"{playerName} attacks;");
            Point target = GetInputPoint();
            enemyMap.IsHit(target);
            enemyMap.DrawMap(showShips);
        }

        public static Point GetInputPoint(){
            Point point = new Point();

            Console.Write("\nx: ");
            point.x =(Char.Parse(Console.ReadLine())) % 64;
                
            Console.Write("y: ");
            point.y = Int32.Parse(Console.ReadLine());

            return point;
        }
        static void Main(string[] args)
        {  
            bool showShips = true;
            
            string player1Name = UI.GetUserName();
            UI.Welcome(player1Name);

            GameMap firstPlayerMap = new GameMap();
            // firstPlayerMap.GetShipCoordinate(Ship.Carrier);
            // firstPlayerMap.GetShipCoordinate(Ship.Battleship);
            // firstPlayerMap.GetShipCoordinate(Ship.Cruiser);
            firstPlayerMap.GetShipCoordinate(Ship.Destroyer);
            
            UI.PrintDotAnimation();
            firstPlayerMap.DrawMap(showShips);
            
            UI.PrintDotAnimation();

            string player2Name = UI.GetUserName();
            UI.Welcome(player2Name);
            GameMap secondPlayerMap = new GameMap();
            // secondPlayerMap.GetShipCoordinate(Ship.Carrier);
            // secondPlayerMap.GetShipCoordinate(Ship.Battleship);
            // secondPlayerMap.GetShipCoordinate(Ship.Cruiser);
            secondPlayerMap.GetShipCoordinate(Ship.Destroyer);
            
            UI.PrintDotAnimation();
            secondPlayerMap.DrawMap(showShips);
            
            while(true){
                Attack(player1Name ,secondPlayerMap);
                if(GameMap.WonGame(secondPlayerMap)){
                    UI.AnnounceWinner(player1Name);
                    break;
                }

                Attack(player2Name, firstPlayerMap);
                if(GameMap.WonGame(firstPlayerMap)){
                    UI.AnnounceWinner(player2Name);
                    break;
                }
            }
            UI.PressEnterToContinue();

        }    
            
    }
}
