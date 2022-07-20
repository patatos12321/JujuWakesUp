using Assets.Scripts.Fighters;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;

namespace Assets.Scripts.Events
{
    class JulieEventChoiceFactory
    {
        public static IEnumerable<JulieEvent> GetNextPossibleEvents()
        {
            if (Flags.CurrentChapter == 1)
            {
                if (Flags.CurrentStep == 1)
                {
                    yield return new JulieFightEvent()
                    {
                        Name = "Octupus fight",
                        Description = "Fight the octopus",
                        FighterType = FighterType.Pieuvre,
                        JulieEventType = JulieEventType.Fight
                    };
                }
                else if (Flags.CurrentStep == 2)
                {
                    yield return new JulieNewFighterEvent()
                    {
                        Name = "Peanut",
                        Description = "Recruit Peanut in your team",
                        JulieEventType = JulieEventType.NewFighter,
                        NewFighter = new FighterPeanut()
                        {
                            KnownMoves = new IFightingMove[] { new MoveBite() }
                        }
                    };
                }
                else
                {
                    yield return new JulieFightEvent()
                    {
                        Name = "Deviljoe fight",
                        Description = "Attempt to overcome the madness",
                        FighterType = FighterType.Deviljoe,
                        JulieEventType = JulieEventType.Fight
                    };
                    yield return new JulieFightEvent()
                    {
                        Name = "Octupus fight",
                        Description = "Fight the octopus",
                        FighterType = FighterType.Pieuvre,
                        JulieEventType = JulieEventType.Fight
                    };
                }
            }
        }
    }
}
