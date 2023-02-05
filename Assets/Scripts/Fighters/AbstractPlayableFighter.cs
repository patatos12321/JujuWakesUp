using Assets.Scripts.FightingGear;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Fighters
{
    public class AbstractPlayableFighter
    {
        public AbstractPlayableFighter()
        {
            
        }
        public IEnumerable<IFightingMove> KnownMoves;
        public List<IFightingGear> FightingGear { get; private set; } = new List<IFightingGear>();
        public List<IFightingMove> FightingMoves => KnownMoves.Union(FightingGear.Where(fg => fg.FightingMove != null).Select(fg => fg.FightingMove)).Distinct().ToList();
        public int CurrentHp { get; set; }

    }
}