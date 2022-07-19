namespace Assets.Scripts.FightingMoves
{
    public interface IFightingMove
    {
        string MoveName { get; }
        int Damage { get; }
        int Duration { get; }
    }
}