namespace Assets.Scripts.Events
{
    public enum JulieEventType { Fight, NewFighter, Heal }

    public class JulieEvent
    {
        public string Name;
        public string Description;
        public JulieEventType JulieEventType;
    }
}
