using System;
using Fleet_Battle;

namespace FleetBattle
{
    
    internal class Program
    {
        static void Main(string[] args)
        {  
            Console.BackgroundColor = ConsoleColor.Black;
            bool showShips = true; // Controls ship visibility in DrawMap()
            
            UI.Welcome(); // Displays welcome message for each player
            string player1Name = UI.GetPlayerName();

            // Initializes individual player maps with ship placement
            GameMap firstPlayerMap = new GameMap();
            firstPlayerMap.GetShipCoordinate(ShipType.Carrier);
            firstPlayerMap.GetShipCoordinate(ShipType.Battleship);
            firstPlayerMap.GetShipCoordinate(ShipType.Cruiser);
            firstPlayerMap.GetShipCoordinate(ShipType.Destroyer);
            

            UI.PrintDotAnimation();
            firstPlayerMap.DrawMap(showShips);
            UI.PressEnterToContinue();
            
            UI.PrintDotAnimation();


            UI.Welcome(); // Displays welcome message for each player
            string player2Name = UI.GetPlayerName();

            //Initializes individual player maps with ship placement
            GameMap secondPlayerMap = new GameMap();
            //secondPlayerMap.GetShipCoordinate(ShipType.Carrier);
            secondPlayerMap.GetShipCoordinate(ShipType.Battleship);
            secondPlayerMap.GetShipCoordinate(ShipType.Cruiser);
            secondPlayerMap.GetShipCoordinate(ShipType.Destroyer);
            
            UI.PrintDotAnimation();
            secondPlayerMap.DrawMap(showShips);
            UI.PressEnterToContinue();
            
            UI.PrintDotAnimation();

            int turn = 1;
            while(true){
                // Displays first-turn message only once for each player
                if(turn == 1){
                    UI.AnnounceBattleStarts();
                }

                // Processes player attack: acquires target, validates, and determines hit/miss
                Attack(player1Name ,secondPlayerMap);
                // Performs win condition check
                if(GameMap.WonGame(secondPlayerMap)){
                    UI.AnnounceWinner(player1Name);
                    break;
                }
                Console.Clear();

                // Displays first-turn message only once for each player
                if(turn == 1){
                    UI.AnnounceBattleStarts();
                    turn++;
                }

                // Processes player attack: acquires target, validates, and determines hit/miss
                Attack(player2Name, firstPlayerMap);
                // Performs win condition check
                if(GameMap.WonGame(firstPlayerMap)){
                    UI.AnnounceWinner(player2Name);
                    break;
                }
                Console.Clear();
            }
            UI.PressEnterToContinue();

        }    

        public static void Attack(string playerName, GameMap enemyMap){
            Console.Clear();
            bool showShips = false;
            Console.WriteLine($"{playerName} attacks;");
            Point target = GetPoint();
            enemyMap.IsHit(target); // Marks hit/miss locations on the player map
            enemyMap.DrawMap(showShips);
            UI.PressEnterToContinue();
        }

        public static Point GetPoint(){
            Point point = new Point();
            
            Char tempCh; 
            int tempInt; 

            try{
                do{
                    Console.Write("\nx: ");
                    tempCh = Char.Parse(Console.ReadLine());
                    tempCh = Char.ToUpper(tempCh);
                    if(tempCh >= 'A' && tempCh <= 'J'){
                        break;
                }
                    UI.PrintRed("Enter a character from A to J");
                    UI.PressEnterToContinue();
                } while(true);
                point.x =(tempCh) % 64;
            
                do{
                Console.Write("y: ");
                tempInt = Int32.Parse(Console.ReadLine());
                if(tempInt > 0 && tempInt <= 10){
                    break;
                }
                UI.PrintRed("Enter a number from 1 to 10");
                UI.PressEnterToContinue();
                }while(true);   
                point.y = tempInt;

            } catch(Exception e){
                Console.WriteLine(e.Message);
            }
            
            return point;
        }
        public static Point GetPoint(ShipType ship){
            ShipType currentShip = ship;
            Console.WriteLine("\nPlace your \"{0}\" vertically/horizontally.\nLength: {1}", ship, (int) ship);

            return GetPoint();
        }
            
    }
}
