using Assets.Scripts.FightingMoves;
using System.Collections.Generic;

namespace Assets.Scripts.Fighters.FighterFactories
{
    public class FighterSpaghettiMonsterFactory : IFighterSpecificFactory
    {
        public IFighter GetFighter()
        {
            return new FighterSpaghettiMonster()
            {
                KnownMoves = new List<IFightingMove>() { new MoveSpaghettiSlap() }.ToArray()
            };
        }
    }
}
