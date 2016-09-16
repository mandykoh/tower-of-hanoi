using System;
using System.Threading;


namespace TowerOfHanoi
{
    public class App
    {
        public static void Main(string[] args)
        {
            var puzzle = new Puzzle(towerCount: 3, diskCount: 4);

            puzzle.Print(Console.Out);

            puzzle.MoveDisks(count: 4, from: 0, to: 2, eachMove: () => {
                Console.Out.WriteLine();
                puzzle.Print(Console.Out);                
            });
        }
    }
}
