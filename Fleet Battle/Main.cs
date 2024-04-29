using System;
using Fleet_Battle;

namespace FleetBattle
{
    
    internal class Program
    {
        
        

        public static void IsHit(int x, int y){

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
            GameMap UserMap = new GameMap();

            UserMap.GetShipCoordinate(Ship.Carrier);
            UserMap.GetShipCoordinate(Ship.Battleship);
            UserMap.GetShipCoordinate(Ship.Cruiser);
            UserMap.GetShipCoordinate(Ship.Destroyer);

            UserMap.DrawMap(true);
            UserMap.DrawMap(false);
            
        }    
            
    }
}
