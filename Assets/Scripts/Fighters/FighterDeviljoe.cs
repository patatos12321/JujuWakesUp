using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Fighters
{
    public class FighterDeviljoe : IFighter
    {
        public FighterDeviljoe()
        {
            CurrentHp = MaxHp;
        }
        public IFightingMove[] KnownMoves;
        public string FighterName => "Deviljoe";
        public int MaxHp => 1000;
        public int CurrentHp { get; set; }
        public List<IFightingMove> FightingMoves => KnownMoves.ToList();
        public string BattleSongName => "Big boss sous sol loop";

        public string SpriteName => "deviljoe";
    }
}