using Assets.Scripts.Fighters;

namespace Assets.Scripts.Events
{
    class JulieFightEvent : JulieEvent
    {
        public JulieFightEvent()
        {
            JulieEventType = JulieEventType.Fight;
        }
        public FighterType FighterType;
    }
}
