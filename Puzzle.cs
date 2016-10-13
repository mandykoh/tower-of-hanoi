using System;

namespace TowerOfHanoi
{
    public class Puzzle
    {
        public int DiskCount { get; }
        public Tower[] Towers { get; }
        
        
        public Puzzle(int towerCount, int diskCount)
        {
            DiskCount = diskCount;
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
        
        
        public void MoveDisks(int count, int from, int to, Action eachMove = null)
        {
            int freeTower;
            for (freeTower = 0; freeTower == from || freeTower == to; ++freeTower) {}

            // Move all disks above us to the free tower
            if (count > 1) {
                MoveDisks(count: count - 1, from: from, to: freeTower, eachMove: eachMove);
            }
            
            // Move us to the destination tower
            MoveDisk(from: from, to: to);

            eachMove?.Invoke();

            // Move all the disks we moved to the free tower back on top of us
            if (count > 1) {
                MoveDisks(count: count - 1, from: freeTower, to: to, eachMove: eachMove);
            }
        }
    }
}
