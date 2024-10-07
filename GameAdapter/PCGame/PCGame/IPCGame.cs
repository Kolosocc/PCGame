namespace GameApp.Models
{
    public interface IPCGame
    {
        string GetTitle();
        int GetPegiAllowedAge();
        bool IsTripleAGame();
        Requirements GetRequirements();
    }
}
