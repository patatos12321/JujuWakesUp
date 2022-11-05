using Assets;
using Assets.Scripts;
using Assets.Scripts.Fighters;
using Assets.Scripts.Fighters.FighterFactories;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestCombat : MonoBehaviour
{
    // Start is called before the first frame update
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

        SharedResources.EnemyFighter = new FighterPieuvreFactory().GetFighter();

        SceneManager.LoadScene("Combat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
