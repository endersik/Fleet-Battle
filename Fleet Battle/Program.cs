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
        public static void DrawMap(int column, int row, bool isHit){
            char columnHeader = 'A';
            int rowHeader = 1;

            for(int x=1; x<=10; x++){
                if(x == 1){
                    Console.Write("  ");
                }
                Console.Write($" {columnHeader} ");
                columnHeader++;
            }
            
            for(int y=1; y<=10; y++){
                Console.Write($"\n{rowHeader}");
                if(y != 10){
                    Console.Write(" ");
                }
                for(int z=1; z<=10;z++){
                    Console.ForegroundColor= ConsoleColor.Blue;
                    if(row == y && (column % 65) == z && isHit){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" x ");
                        Console.ForegroundColor= ConsoleColor.Blue;
                    }
                    else if(row == y && (column % 65) == z && isHit){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" x ");
                        Console.ForegroundColor= ConsoleColor.Blue;
                    }
                    else{
                        Console.Write(" x ");
                    }
                    
                }
                Console.ForegroundColor= ConsoleColor.White;
                rowHeader++;
            }
        
        }
        static void Main(string[] args)
        {   
            while(true)
            {
                Console.Write("\nEnter column header: ");
                int columnHeader =(Char.Parse(Console.ReadLine())) % 64;
                Console.WriteLine(columnHeader);
                
                Console.Write("Enter row header: ");
                int rowHeader = Int32.Parse(Console.ReadLine());
                Console.WriteLine(rowHeader);

                Point shot = new Point(columnHeader, rowHeader);
                bool isHit = true;

                DrawMap(shot.x, shot.y, isHit);
            }
        }    
            
    }
}
