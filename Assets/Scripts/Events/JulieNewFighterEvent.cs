using Assets.Scripts.Fighters;

namespace Assets.Scripts.Events
{
    class JulieNewFighterEvent : JulieEvent
    {
        public JulieNewFighterEvent()
        {
            JulieEventType = JulieEventType.NewFighter;
        }
        public IFighter NewFighter;
    }
}
