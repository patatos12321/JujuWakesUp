using Assets.Scripts.FightingMoves;

namespace Assets.Scripts.FightingGear
{
    public class FightingGearSpaghettiMonsterArm : IFightingGear
    {
        public FightingGearSpaghettiMonsterArm()
        {

        }

        public IFightingMove FightingMove => new MoveSpaghettiSlap();

        public string SpriteName => "spaghetti_monster_arm";
    }
}
