using System;


namespace TowerOfHanoi
{
    public class App
    {
        public static void Main(string[] args)
        {
            var puzzle = new Puzzle(towerCount: 3, diskCount: 4);
            var printer = new PuzzlePrinter(Console.Out);

            printer.Print(puzzle);

            puzzle.MoveDisks(count: 4, from: 0, to: 2, eachMove: () => {
                Console.Out.WriteLine();
                printer.Print(puzzle);
            });
        }
    }
}
