using System.IO;


namespace TowerOfHanoi
{
    public class Puzzle
    {
        int diskCount;
        
        public Tower[] Towers { get; }
        
        
        public Puzzle(int towerCount, int diskCount)
        {
            this.diskCount = diskCount;
            
            Towers = new Tower[towerCount];
            
            // Put all the disks on the first tower
            Towers[0] = new Tower(diskCount: diskCount);
            
            // Make the rest of the towers empty
            for (var i = 1; i < towerCount; ++i) {
                Towers[i] = new Tower(diskCount: 0);
            }
        }
        
        
        public void MoveDisk(int from, int to)
        {
            var disk = Towers[from].TakeDisk();
            Towers[to].AddDisk(disk);
        }
        
        
        public void Print(TextWriter writer)
        {
            var baseRadius = diskCount + 1;
            
            // Show first row (containing only the tips of spokes)
            for (var i = 0; i < Towers.Length; ++i) {
                PrintSpaces(count: baseRadius, to: writer);
                writer.Write("|");
                PrintSpaces(count: baseRadius, to: writer);
            }
            writer.WriteLine();
            
            // Show the disks
            for (var diskRow = diskCount; diskRow > 0; --diskRow) {
                foreach (var tower in Towers) {
                    
                    // No disk at this row - show a spoke
                    if (tower.Disks.Count < diskRow) {
                        PrintSpaces(count: baseRadius, to: writer);
                        writer.Write("|");
                        PrintSpaces(count: baseRadius, to: writer);
                        
                    // Disk here - show it
                    } else {
                        var disk = tower.Disks[diskRow - 1];
                        PrintSpaces(count: baseRadius - disk.Size, to: writer);
                        writer.Write("[");
                        PrintSpaces(count: disk.Size - 1, to: writer);
                        
                        writer.Write("|");
                        
                        PrintSpaces(count: disk.Size - 1, to: writer);
                        writer.Write("]");
                        PrintSpaces(count: baseRadius - disk.Size, to: writer);
                    }
                }
                writer.WriteLine();
            }
            
            // Show last row (containing the bases of the towers)
            for (var i = 0; i < Towers.Length; ++i) {
                for (var j = 0; j < (baseRadius * 2 + 1); ++j) {
                    writer.Write("=");
                }
            }
            writer.WriteLine();
        }
        
        
        void PrintSpaces(int count, TextWriter to)
        {
            for (var i = 0; i < count; ++i) {
                to.Write(" ");
            }
        }
    }
}