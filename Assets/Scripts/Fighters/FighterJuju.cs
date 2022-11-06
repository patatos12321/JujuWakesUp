using Assets.Scripts.FightingGear;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Fighters
{
    public class FighterJuju : IFighter
    {
        public FighterJuju()
        {
            CurrentHp = MaxHp;
        }

        public IEnumerable<IFightingMove> KnownMoves;
        public string FighterName => "Juju";

        public int MaxHp => 50;

        public int CurrentHp { get; set; }

        public List<IFightingMove> FightingMoves => KnownMoves.Union(FightingGear.Where(fg => fg.FightingMove != null).Select(fg => fg.FightingMove)).Distinct().ToList();

        //Juju a pas de tune spéciale
        public string BattleSongName => "";

        public string SpriteName => "juju";

        public List<IFightingGear> FightingGear { get; private set; } = new List<IFightingGear>();
    }
}