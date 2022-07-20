using Assets;
using Assets.Scripts;
using Assets.Scripts.Fighters;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour
{
    void Start()
    {
        Flags.CurrentChapter = 1;
        Flags.CurrentStep = 1;

        SharedResources.PlayerFighters = new List<IFighter>
        {
            new FighterJuju()
            {
                KnownMoves = new IFightingMove[] { new MoveOya() }
            }
        };
    }
}
