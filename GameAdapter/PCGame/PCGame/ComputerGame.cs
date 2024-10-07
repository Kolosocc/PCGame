using GameApp.Models;

namespace GameApp.Models
{
    public class ComputerGame
    {
        private string name;
        private PegiAgeRating pegiAgeRating;
        private double budgetInMillionsOfDollars;
        private int minimumGpuMemoryInMegabytes;
        private int diskSpaceNeededInGb;
        private int ramNeededInGB;
        private int coresNeeded;
        private double coreSpeedInGhz;

        public ComputerGame(string name,
                            PegiAgeRating pegiAgeRating,
                            double budgetInMillionsOfDollars,
                            int minimumGpuMemoryInMegabytes,
                            int diskSpaceNeededInGb,
                            int ramNeededInGB,
                            int coresNeeded,
                            double coreSpeedInGhz)
        {
            this.name = name;
            this.pegiAgeRating = pegiAgeRating;
            this.budgetInMillionsOfDollars = budgetInMillionsOfDollars;
            this.minimumGpuMemoryInMegabytes = minimumGpuMemoryInMegabytes;
            this.diskSpaceNeededInGb = diskSpaceNeededInGb;
            this.ramNeededInGB = ramNeededInGB;
            this.coresNeeded = coresNeeded;
            this.coreSpeedInGhz = coreSpeedInGhz;
        }

        public string GetName() => name;
        public PegiAgeRating GetPegiAgeRating() => pegiAgeRating;
        public double GetBudgetInMillionsOfDollars() => budgetInMillionsOfDollars;
        public int GetMinimumGpuMemoryInMegabytes() => minimumGpuMemoryInMegabytes;
        public int GetDiskSpaceNeededInGb() => diskSpaceNeededInGb;
        public int GetRamNeededInGB() => ramNeededInGB;
        public int GetCoresNeeded() => coresNeeded;
        public double GetCoreSpeedInGhz() => coreSpeedInGhz;
    }
}
