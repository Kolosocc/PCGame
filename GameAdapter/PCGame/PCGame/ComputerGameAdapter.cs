namespace GameApp.Models
{
    public class ComputerGameAdapter : IPCGame
    {
        private ComputerGame computerGame;

        public ComputerGameAdapter(ComputerGame computerGame)
        {
            this.computerGame = computerGame;
        }

        public string GetTitle() => computerGame.GetName();

        public int GetPegiAllowedAge()
        {
            return computerGame.GetPegiAgeRating() switch
            {
                PegiAgeRating.P3 => 3,
                PegiAgeRating.P7 => 7,
                PegiAgeRating.P12 => 12,
                PegiAgeRating.P16 => 16,
                PegiAgeRating.P18 => 18,
                _ => 0
            };
        }

        public bool IsTripleAGame() => computerGame.GetBudgetInMillionsOfDollars() > 50;

        public Requirements GetRequirements()
        {
            return new Requirements(
                (int)Math.Ceiling((double)computerGame.GetMinimumGpuMemoryInMegabytes() / 8192),
                (int)Math.Ceiling((double)computerGame.GetDiskSpaceNeededInGb() / 8),
                computerGame.GetRamNeededInGB(),
                computerGame.GetCoreSpeedInGhz(),
                computerGame.GetCoresNeeded()
            );
        }
    }
}
