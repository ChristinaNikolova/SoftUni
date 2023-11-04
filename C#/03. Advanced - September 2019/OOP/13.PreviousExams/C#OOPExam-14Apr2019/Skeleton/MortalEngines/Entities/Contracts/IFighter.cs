namespace MortalEngines.Entities.Contracts
{
    public interface IFighter : IMachine
    {
        abstract bool AggressiveMode { get; }

        void ToggleAggressiveMode();
    }
}