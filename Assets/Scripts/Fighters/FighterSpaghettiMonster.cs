using Assets.Scripts.FightingGear;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Fighters
{
    public class FighterSpaghettiMonster : IFighter
    {
        public FighterSpaghettiMonster()
        {
            CurrentHp = MaxHp;
        }
        public IFightingMove[] KnownMoves;
        public string FighterName => "Pierre";
        public int MaxHp => 60;
        public int CurrentHp { get; set; }
        public List<IFightingMove> FightingMoves => KnownMoves.ToList();
        public string BattleSongName => "Big boss sous sol loop";
        public string SpriteName => "spaghetti_monster";
        public List<IFightingGear> FightingGear => new List<IFightingGear>();
    }
}