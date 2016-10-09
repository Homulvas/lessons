using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {     
            // C++ int foo[5][5] different order
            // can initialize values without the need to initialize the array itself.
            // jagged or multidiminesional array?
            int[,] multigrid = new int[5,5] {{0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}};
            int a = multigrid[1,1];  
            int[][] grid =  {new [] {0,0,0,0,0},
                            new [] {0,0,0,0,0},
                            new [] {0,0,1,0,0},
                            new [] {0,0,1,0,0},
                            new [] {0,0,0,0,0}}; 

            int[,] hits = new int[5,5];

            int[][] test = new int[5][]; // painful to initialize need to create new array for each loop if we create value in for/for
            test[0] = new int[5];
            test[1] = new int[5];
            test[2] = new int[5];
            test[3] = new int[5];
            test[4] = new int[5];

            int[,] test2 = new int[5,5]; // ez to initialize. can add values without initializing any more arrays. initializes to 0
            Console.WriteLine($"{hits[0,0]}");
            while(true)
            {
                // foreach works different compared to jagged arrays.
                // foreach(var aa in hits) {
                    
                // }

                // Console.WriteLine("Enter coordinates");
                // Console.WriteLine("x");
                // int x = Convert.ToInt32(Console.ReadLine());
                // Console.WriteLine("y");
                // int y = Convert.ToInt32(Console.ReadLine());

                Tuple<int,int> move = MakeAMove(hits);

                int x = move.Item1;
                int y = move.Item2;
                
                if (grid[x][y] == 1) {
                    grid[x][y] = 0;
                    hits[x,y] = 2;
                } else {
                    hits[x,y] = 1;
                }
                

                bool done = true;
                foreach(int[] line in grid)
                {
                    foreach(int cell in line)
                    {
                        if (cell == 1) {
                            done = false;
                            // GOTO?
                            break;
                        } 
                    }
                    if (done == false)
                    {
                        break;
                    }
                }

                DrawMap(hits);


                if (done)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("Game over!");
            Console.ReadKey();
        }

        public static void DrawMap(int[,] hits)
        {
                for (int xx= 0; xx < hits.GetLength(0); xx++)
                {
                    for (int yy= 0; yy < hits.GetLength(0); yy++)
                    { 
                        Console.Write(hits[xx,yy]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
        }

        public static Tuple<int, int> MakeAMove(int[,] hits)
        {
            for (int xx= 0; xx < hits.GetLength(0); xx++)
                {
                    for (int yy= 0; yy < hits.GetLength(0); yy++)
                    { 
                        if (hits[xx,yy] == 0)
                        {
                            return Tuple.Create(xx,yy);
                        }
                    }
                }
            throw new Exception("fail");
        }
    }
}
