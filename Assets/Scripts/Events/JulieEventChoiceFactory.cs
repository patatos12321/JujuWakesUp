using Assets.Scripts.Fighters;
using Assets.Scripts.FightingGear;
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
                        AlienJuiceReward = 1,
                        GearReward = new FightingGearOctopusLeg()
                    };
                }
                else if (Flags.CurrentStep == 2)
                {
                    yield return new JulieNewFighterEvent()
                    {
                        Name = "Peanut",
                        Description = "Recruit Peanut in your team",
                        NewFighter = new FighterPeanut()
                        {
                            KnownMoves = new IFightingMove[] { new MoveBite() }
                        }
                    };
                }
                else
                {
                    yield return new JulieHealEvent();
                    yield return new JulieFightEvent()
                    {
                        Name = "Octupus fight",
                        Description = "Fight the octopus",
                        FighterType = FighterType.Pieuvre,
                    };
                    yield return new JulieFightEvent()
                    {
                        Name = "Spaghetti Monster",
                        Description = "Eat the delicious treat",
                        FighterType = FighterType.SpaghettiMonster,
                        AlienJuiceReward = 3,
                        GearReward = new FightingGearSpaghettiMonsterArm()
                    };
                }
            }
        }
    }
}
