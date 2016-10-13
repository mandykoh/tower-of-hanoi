using System.IO;

namespace TowerOfHanoi
{
    public class PuzzlePrinter
    {
        readonly TextWriter _writer;


        public PuzzlePrinter(TextWriter writer)
        {
            _writer = writer;
        }


        public void Print(Puzzle puzzle)
        {
            var baseRadius = puzzle.DiskCount + 1;
            
            // Show first row (containing only the tips of spokes)
            for (var i = 0; i < puzzle.Towers.Length; ++i) {
                PrintSpaces(count: baseRadius, to: _writer);
                _writer.Write("|");
                PrintSpaces(count: baseRadius, to: _writer);
            }
            _writer.WriteLine();
            
            // Show the disks
            for (var diskRow = puzzle.DiskCount; diskRow > 0; --diskRow) {
                foreach (var tower in puzzle.Towers) {
                    
                    // No disk at this row - show a spoke
                    if (tower.Disks.Count < diskRow) {
                        PrintSpaces(count: baseRadius, to: _writer);
                        _writer.Write("|");
                        PrintSpaces(count: baseRadius, to: _writer);
                    }

                    // Disk here - show it
                    else {
                        var disk = tower.Disks[diskRow - 1];
                        PrintSpaces(count: baseRadius - disk.Size, to: _writer);
                        _writer.Write("[");
                        PrintSpaces(count: disk.Size - 1, to: _writer);
                        
                        _writer.Write("|");
                        
                        PrintSpaces(count: disk.Size - 1, to: _writer);
                        _writer.Write("]");
                        PrintSpaces(count: baseRadius - disk.Size, to: _writer);
                    }
                }
                _writer.WriteLine();
            }
            
            // Show last row (containing the bases of the towers)
            for (var i = 0; i < puzzle.Towers.Length; ++i) {
                for (var j = 0; j < (baseRadius * 2 + 1); ++j) {
                    _writer.Write("=");
                }
            }
            _writer.WriteLine();
        }


        static void PrintSpaces(int count, TextWriter to)
        {
            for (var i = 0; i < count; ++i) {
                to.Write(" ");
            }
        }
    }
}
