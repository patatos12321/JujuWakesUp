using Assets.Fighters.FighterFactories;
using System;
using UnityEngine;

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
}
