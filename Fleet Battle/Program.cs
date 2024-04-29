using System;

namespace FleetBattle
{
    struct Point{
        public int x;
        public int y;

        public Point(int x, int y){
            this.x = x;
            this.y = y;
        }
    }

    
    internal class Program
    {
        static int[,] Map = new int[10,10];
        static int placed = 1;
        static int hit = 2;
        static int miss = 3;

        public static void DrawMap(){
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
                    if(Map[y,z] == placed){
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" x ");
                        Console.ForegroundColor= ConsoleColor.Blue;
                    }
                    else if(Map[y,z] == hit){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" x ");
                        Console.ForegroundColor= ConsoleColor.Blue;
                    }
                    else if(Map[y,z] == miss){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" x ");
                        Console.ForegroundColor= ConsoleColor.Blue;
                    }
                    else{
                        Console.Write(" x ");
                    }
                    
                }
                Console.ForegroundColor= ConsoleColor.White;
            }
            Console.ReadLine();
        }
        public enum Ship{
            Carrier = 5,
            Battleship = 4,
            Cruiser = 3,
            Destroyer = 2
        }

        public static void PlaceShip(Ship ship){
            DrawMap();
            Point startPoint = GetInputPoint();
            Point endPoint = GetInputPoint();
            Console.Clear();
            int shipLength;
            switch(ship){
                case Ship.Carrier:
                    shipLength = (int) Ship.Carrier;
                    if(startPoint.x == endPoint.x && ((Math.Abs(startPoint.y - endPoint.y)) + 1) == shipLength){
                        PlaceVertically(startPoint, endPoint);                        
                    }
                    else if(startPoint.y == endPoint.y && ((Math.Abs(startPoint.x - endPoint.x)) + 1) == shipLength){
                        PlaceHorizontally(startPoint,endPoint);
                    }
                    break;
                case Ship.Battleship:
                    shipLength = (int) Ship.Battleship;
                    if(startPoint.x == endPoint.x && ((Math.Abs(startPoint.y - endPoint.y)) + 1) == shipLength){
                        PlaceVertically(startPoint, endPoint);                        
                    }
                    else if(startPoint.y == endPoint.y && ((Math.Abs(startPoint.x - endPoint.x)) + 1) == shipLength){
                        PlaceHorizontally(startPoint,endPoint);
                    }
                    break;
                case Ship.Cruiser:
                    shipLength = (int) Ship.Cruiser;
                    if(startPoint.x == endPoint.x && ((Math.Abs(startPoint.y - endPoint.y)) + 1) == shipLength){
                        PlaceVertically(startPoint, endPoint);                        
                    }
                    else if(startPoint.y == endPoint.y && ((Math.Abs(startPoint.x - endPoint.x)) + 1) == shipLength){
                        PlaceHorizontally(startPoint,endPoint);
                    }
                    break;
                case Ship.Destroyer:
                    shipLength = (int) Ship.Destroyer;
                    if(startPoint.x == endPoint.x && ((Math.Abs(startPoint.y - endPoint.y)) + 1) == shipLength){
                        PlaceVertically(startPoint, endPoint);                        
                    }
                    else if(startPoint.y == endPoint.y && ((Math.Abs(startPoint.x - endPoint.x)) + 1) == shipLength){
                        PlaceHorizontally(startPoint,endPoint);
                    }
                    break;
            }
        }
    
        public static void PlaceVertically(Point startPoint, Point endPoint){
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

        public static void PlaceHorizontally(Point startPoint, Point endPoint){
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

        public static void IsHit(int x, int y){

        }

        public static Point GetInputPoint(){
            Point point = new Point();

            Console.Write("\nEnter column header: ");
            point.x =(Char.Parse(Console.ReadLine())) % 64;
            Console.WriteLine(point.x);
                
            Console.Write("Enter row header: ");
            point.y = Int32.Parse(Console.ReadLine());
            Console.WriteLine(point.y);

            return point;
        }
        static void Main(string[] args)
        {  
            PlaceShip(Ship.Carrier);
            PlaceShip(Ship.Battleship);
            PlaceShip(Ship.Cruiser);
            PlaceShip(Ship.Destroyer);

            DrawMap();
            
        }    
            
    }
}
