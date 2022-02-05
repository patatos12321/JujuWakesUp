using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Fighters.FighterFactories
{
    public interface IFighterSpecificFactory
    {
        IFighter GetFighter();
    }
}
