namespace Assets.Scripts.Events
{
    public class JulieHealEvent : JulieEvent
    {
        public JulieHealEvent()
        {
            Name = "Bonfire";
            Description = "Heal your team";
            JulieEventType = JulieEventType.Heal;
        }
    }
}
