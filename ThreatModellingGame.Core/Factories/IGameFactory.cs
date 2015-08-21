namespace ThreatModellingGame.Core.Factories
{
    public interface IGameFactory
    {
        IGame Create(string name);
    }
}