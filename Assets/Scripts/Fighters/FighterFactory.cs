using Assets.Scripts.Fighters.FighterFactories;
using System;
using UnityEngine;

namespace Assets.Scripts.Fighters
{
    public enum FighterType
    {
        Pieuvre,
        Deviljo
    }

    public class FighterFactory : MonoBehaviour
    {
        public FighterType fighterType;
        public int fighterLevel;

        public IFighter GetFighter()
        {
            switch (fighterType)
            {
                case FighterType.Pieuvre:
                    return new FighterPieuvreFactory().GetFighter();
                case FighterType.Deviljo:
                    throw new NotImplementedException();
                default:
                    break;
            }
            throw new Exception("This should not happen! Unable to get a fighter.");
        }

        public static IFighter GetFighter(FighterType fighterType)
        {
            switch (fighterType)
            {
                case FighterType.Pieuvre:
                    return new FighterPieuvreFactory().GetFighter();
                case FighterType.Deviljo:
                    throw new NotImplementedException();
                default:
                    break;
            }
            throw new Exception("This should not happen! Unable to get a fighter.");
        }
    }
}