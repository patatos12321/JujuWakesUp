using Assets.Scripts.FightingMoves;

namespace Assets.Scripts.FightingGear
{
    public class FightingGearOctopusLeg : IFightingGear
    {
        public FightingGearOctopusLeg()
        {

        }

        public IFightingMove FightingMove => new MoveSquirt();
    }
}
