using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int turn = 0;
            int[] array = new int[9] { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            while(true)
            {
                for(int i=0; i<3;i++)
                {
                    for(int j=0; j<3;j++)
                    {
                        if (array[i * 3 + j] == 2)
                            Console.Write("     |");
                        if (array[i * 3 + j] == 0)
                            Console.Write("  {0}  |", 'O');
                        if (array[i * 3 + j] == 1)
                            Console.Write("  {0}  |", 'X');
                    }
                    Console.WriteLine();
                    Console.WriteLine("------------------");
                    Console.WriteLine();
                }
                Console.WriteLine("enter index from 0 -> 8");
                string input=Console.ReadLine();
                array[int.Parse(input)] = 0;
                solve newplay = new solve(array);
                array=newplay.choose_next_play(array);
            }
        }
    }
}
