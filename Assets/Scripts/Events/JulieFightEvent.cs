using Assets.Scripts.Fighters;
using Assets.Scripts.FightingGear;

namespace Assets.Scripts.Events
{
    class JulieFightEvent : JulieEvent
    {
        public JulieFightEvent()
        {
            JulieEventType = JulieEventType.Fight;
        }
        public FighterType FighterType;
        public IFightingGear GearReward;
        public int AlienJuiceReward;
    }
}
