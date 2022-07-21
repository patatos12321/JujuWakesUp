using Assets.Scripts.Fighters.FighterFactories;
using System;
using UnityEngine;

namespace Assets.Scripts.Fighters
{
    public enum FighterType
    {
        Pieuvre,
        Deviljoe,
        SpaghettiMonster
    }

    public class FighterFactory : MonoBehaviour
    {
        public FighterType fighterType;
        public int fighterLevel;


        public static IFighter GetFighter(FighterType fighterType)
        {
            switch (fighterType)
            {
                case FighterType.Pieuvre:
                    return new FighterPieuvreFactory().GetFighter();
                case FighterType.Deviljoe:
                    return new FighterDeviljoeFactory().GetFighter();
                case FighterType.SpaghettiMonster:
                    return new FighterSpaghettiMonsterFactory().GetFighter();
                default:
                    break;
            }
            throw new Exception("This should not happen! Unable to get a fighter.");
        }

        #region oldCode
        [Obsolete]
        public IFighter GetFighter()
        {
            switch (fighterType)
            {
                case FighterType.Pieuvre:
                    return new FighterPieuvreFactory().GetFighter();
                case FighterType.Deviljoe:
                    throw new NotImplementedException();
                default:
                    break;
            }
            throw new Exception("This should not happen! Unable to get a fighter.");
        }
        #endregion
    }
}