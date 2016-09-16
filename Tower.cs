using System.Collections.Generic;


namespace TowerOfHanoi
{
    public class Tower
    {
        public List<Disk> Disks { get; }
        
        
        public Tower(int diskCount)
        {
            Disks = new List<Disk>();
            
            for (var i = diskCount; i > 0; --i) {
                var aNewDisk = new Disk(size: i);
                Disks.Add(aNewDisk);
            }
        }
        
        
        public void AddDisk(Disk disk)
        {
            Disks.Add(disk);
        }
        
        
        public Disk TakeDisk()
        {
            var lastDiskIndex = Disks.Count - 1;
            var disk = Disks[lastDiskIndex];
            Disks.RemoveAt(lastDiskIndex);
            
            return disk;
        }
    }
}
