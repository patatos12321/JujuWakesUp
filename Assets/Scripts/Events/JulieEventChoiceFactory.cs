using System.Collections.Generic;

namespace Assets.Scripts.Events
{
    class JulieEventChoiceFactory
    {
        public static IEnumerable<JulieEvent> GetNextPossibleEvents()
        {
            yield return new JulieFightEvent()
            {
                Name = "Octupus fight",
                Description = "Fight the octopus",
                FighterType = Fighters.FighterType.Pieuvre,
                JulieEventType = JulieEventType.Fight
            };
        }
    }
}
