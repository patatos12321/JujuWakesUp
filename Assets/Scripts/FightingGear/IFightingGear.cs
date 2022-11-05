using Assets.Scripts.FightingMoves;

namespace Assets.Scripts.FightingGear
{
    public interface IFightingGear
    {
        IFightingMove FightingMove { get; }
    }
}
