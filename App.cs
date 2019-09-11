using System;


namespace TowerOfHanoi
{
    public class App
    {
        public static void Main(string[] args)
        {
            const int TowerCount = 3;
            const int DiskCount = 3;

            var puzzle = new Puzzle(towerCount: TowerCount, diskCount: DiskCount);
            var printer = new PuzzlePrinter(Console.Out);

            printer.Print(puzzle);

            puzzle.MoveDisks(count: DiskCount, from: 0, to: TowerCount - 1, eachMove: () => {
                Console.Out.WriteLine();
                printer.Print(puzzle);
            });
        }
    }
}
