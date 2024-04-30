using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetBattle;

namespace Fleet_Battle
{
    public struct Point{
        public int x;
        public int y;

        public Point(int x, int y){
            this.x = x;
            this.y = y;
        }
    }
    public enum ShipType{
        Carrier = 5,
        Battleship = 4,
        Cruiser = 3,
        Destroyer = 2
    }
    public class GameMap
    {
        private int[,] Map = new int[10,10];
        private static int placed = 1;
        private static int hit = 2;
        private static int miss = 3;

        public void DrawMap(bool showShips){
            Console.Clear();
            char columnHeader = 'A';

            for(int x=0; x<10; x++){
                if(x == 0){
                    Console.Write("  ");
                }
                Console.Write($" {columnHeader} ");
                columnHeader++;
            }
            
            for(int y=0; y<10; y++){
                int row = y+1;
                Console.Write($"\n{row}");
                if(row != 10){
                    Console.Write(" ");
                }
                for(int z=0; z<10;z++){
                    
                    if(showShips && Map[y,z] == placed){
                        UI.MarkShipWithGreen(" X ");
                    }
                    else if(Map[y,z] == hit){
                        UI.MarkHitWithRed(" X ");
                    }
                    else if(Map[y,z] == miss){
                        Console.Write(" X ");
                    }
                    else{
                        UI.MarkOceanWithBlue(" X ");
                    }
                }
            }
        }
    

        
        public void GetShipCoordinate(ShipType ship){
            bool showShips = true;
            DrawMap(showShips);
            Point startPoint = Program.GetPoint(ship);
            Point endPoint = Program.GetPoint(ship);
            Console.Clear();
            int shipLength;
            switch(ship){
                case ShipType.Carrier:
                    shipLength = (int) ShipType.Carrier;
                    PlaceShip(startPoint, endPoint, shipLength);
                    break;
                case ShipType.Battleship:
                    shipLength = (int) ShipType.Battleship;
                    PlaceShip(startPoint, endPoint, shipLength);
                    break;
                case ShipType.Cruiser:
                    shipLength = (int) ShipType.Cruiser;
                    PlaceShip(startPoint, endPoint, shipLength);
                    break;
                case ShipType.Destroyer:
                    shipLength = (int) ShipType.Destroyer;
                    PlaceShip(startPoint, endPoint, shipLength);
                    break;
            }
        }

        public void PlaceShip(Point startPoint, Point endPoint, int shipLength){
            if(startPoint.x == endPoint.x && ((Math.Abs(startPoint.y - endPoint.y)) + 1) == shipLength){
                PlaceVertically(startPoint, endPoint);                        
            }
            else if(startPoint.y == endPoint.y && ((Math.Abs(startPoint.x - endPoint.x)) + 1) == shipLength){
                PlaceHorizontally(startPoint,endPoint);
            }
        }

        public void PlaceVertically(Point startPoint, Point endPoint){
            if(startPoint.y < endPoint.y){
                for(int y = startPoint.y; y<=endPoint.y; y++){
                    int row = y;
                    int col = startPoint.x;
                    Map[row-1,col-1] = placed;
                }
            }
            else{
                for(int y = endPoint.y; y<=startPoint.y; y++){
                    int row = y;
                    int col = startPoint.x;
                    Map[row-1,col-1] = placed;
                }
            }
        }

        public void PlaceHorizontally(Point startPoint, Point endPoint){
            if(startPoint.x < endPoint.x){
                for(int x = startPoint.x; x<=endPoint.x; x++){
                    int row = startPoint.y;
                    int col = x;
                    Map[row-1,col-1] = placed; // Adjusts row, col for zero-based indexing
                }
            }
            else{
                for(int x = endPoint.x; x<=startPoint.x; x++){
                    int row = startPoint.y;
                    int col = x;
                    Map[row-1,col-1] = placed; 
                }
            }
        }

        // Marks hit/miss locations on the player map
        public void IsHit(Point shot){
            int row = shot.y;
            int col = shot.x;
            // Adjusts row, col for zero-based indexing
            if(this.Map[row-1,col-1] == placed){
                this.Map[row-1,col-1] = hit;
                UI.PrintRed("Hit!!");
                UI.PressEnterToContinue();

            }
            else if(this.Map[row-1,col-1] == miss || this.Map[row-1,col-1] == hit){
                UI.PrintRed("You have already targeted this area!");
                UI.PressEnterToContinue();
            }
            else{
                this.Map[row-1,col-1] = miss;
                Console.WriteLine("Miss...");
                UI.PressEnterToContinue();
            }
        }

        public static bool WonGame(GameMap enemyMap){
            int hitCount = 0;
            for(int i = 0; i < 10; i++){
                for(int j = 0; j < 10; j++){
                    if(enemyMap.Map[i,j] == hit){
                        hitCount++;
                    } 
                }
            }
            // Checks if hit count matches ship length (sunk)
            // return hitCount == 14 ? true : false;
            return hitCount == 9 ? true : false;
        }
    }

    
}