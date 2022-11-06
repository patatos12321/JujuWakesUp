using Assets.Scripts.FightingGear;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    public class Inventory
    {
        public int NbAlienJuice = 0;
        public List<IFightingGear> FightingGears = new List<IFightingGear>();
    }
}
