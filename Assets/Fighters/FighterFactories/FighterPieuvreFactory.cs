using System.Collections.Generic;

namespace Assets.Fighters.FighterFactories
{
    public class FighterPieuvreFactory : IFighterSpecificFactory
    {
        public IFighter GetFighter()
        {
            return new FighterPieuvre()
            {
                KnownMoves = new List<IFightingMove>() { new MoveSquirt() }.ToArray()
                //Il faut ajouter une nouvelle propriété du fighter pour dire "MaMusic = "WhateverLeNomDeMaTuneDePieuvre""
            };
        }
    }
}
