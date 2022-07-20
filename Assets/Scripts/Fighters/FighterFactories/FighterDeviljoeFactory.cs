using Assets.Scripts.FightingMoves;
using System.Collections.Generic;

namespace Assets.Scripts.Fighters.FighterFactories
{
    public class FighterDeviljoeFactory : IFighterSpecificFactory
    {
        public IFighter GetFighter()
        {
            return new FighterDeviljoe()
            {
                KnownMoves = new List<IFightingMove>() { new MoveMindDestruction() }.ToArray()
            };
        }
    }
}
