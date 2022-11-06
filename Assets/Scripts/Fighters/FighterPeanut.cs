using Assets.Scripts.FightingGear;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Fighters
{
    public class FighterPeanut : IFighter
    {
        public FighterPeanut()
        {
            CurrentHp = MaxHp;
        }

        public IFightingMove[] KnownMoves;
        public string FighterName => "Peanut";

        public int MaxHp => 20;

        public int CurrentHp { get; set; }

        public List<IFightingMove> FightingMoves => KnownMoves.ToList();

        //Peanut a pas de tune sp�ciale
        public string BattleSongName => "";

        public string SpriteName => "Peanut";
        public List<IFightingGear> FightingGear { get; private set; } = new List<IFightingGear>();
    }
}