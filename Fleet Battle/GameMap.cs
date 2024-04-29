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
    public enum Ship{
        Carrier = 5,
        Battleship = 4,
        Cruiser = 3,
        Destroyer = 2
    }
    public class GameMap
    {
        private int[,] Map = new int[10,10];
        private int placed = 1;
        private int hit = 2;
        private int miss = 3;

        public void DrawMap(bool showShips){
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
                    Console.ForegroundColor= ConsoleColor.Blue;
                    if(showShips && Map[y,z] == placed){
                        UI.MarkShipWithGreen(" X ");
                    }
                    else if(Map[y,z] == hit){
                        UI.MarkHitWithRed(" X ");
                    }
                    else if(Map[y,z] == miss){
                        UI.MarkMissWithWhite(" X ");
                    }
                    else{
                        Console.Write(" X ");
                    }
                    
                }
                Console.ForegroundColor= ConsoleColor.White;
            }
            Console.ReadLine();
        }
    

        
        public void GetShipCoordinate(Ship ship){
            bool showShips = true;
            DrawMap(showShips);
            Point startPoint = Program.GetInputPoint();
            Point endPoint = Program.GetInputPoint();
            Console.Clear();
            int shipLength;
            switch(ship){
                case Ship.Carrier:
                    shipLength = (int) Ship.Carrier;
                    PlaceShip(startPoint, endPoint, shipLength);
                    break;
                case Ship.Battleship:
                    shipLength = (int) Ship.Battleship;
                    PlaceShip(startPoint, endPoint, shipLength);
                    break;
                case Ship.Cruiser:
                    shipLength = (int) Ship.Cruiser;
                    PlaceShip(startPoint, endPoint, shipLength);
                    break;
                case Ship.Destroyer:
                    shipLength = (int) Ship.Destroyer;
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
                    Map[row-1,col-1] = placed;
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
    }

    
}