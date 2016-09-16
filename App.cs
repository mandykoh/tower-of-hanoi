using System;


namespace TowerOfHanoi
{
    public class App
    {
        public static void Main(string[] args)
        {
            var puzzle = new Puzzle(towerCount: 3, diskCount: 4);
            //puzzle.MoveDisk(from: 0, to: 1);
            //puzzle.MoveDisk(from: 0, to: 2);
            
            puzzle.Print(Console.Out);
        }
    }
}
