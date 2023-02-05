using Assets.Scripts.FightingGear;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Fighters
{
    public class AbstractEnemyFighter
    {
        public AbstractEnemyFighter()
        {

        }
        public IFightingMove[] KnownMoves;
        public int CurrentHp { get; set; }
        public List<IFightingMove> FightingMoves => KnownMoves.ToList();
        public List<IFightingGear> FightingGear => new List<IFightingGear>();
        public int MaxInventorySize => 0;
    }
}