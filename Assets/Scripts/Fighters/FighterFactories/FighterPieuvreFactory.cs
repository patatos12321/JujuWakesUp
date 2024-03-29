﻿using Assets.Scripts.FightingMoves;
using System.Collections.Generic;

namespace Assets.Scripts.Fighters.FighterFactories
{
    public class FighterPieuvreFactory : IFighterSpecificFactory
    {
        public IFighter GetFighter()
        {
            return new FighterPieuvre()
            {
                KnownMoves = new List<IFightingMove>() { new MoveSquirt() }.ToArray()
            };
        }
    }
}
