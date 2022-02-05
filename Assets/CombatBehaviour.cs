using System.Linq;
using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatBehaviour : MonoBehaviour
{
    private bool InBetweenTurn = true;
    public Text EnemyNameText;
    public Text PlayerNameText;
    public Text PlayerMoveOneText;
    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer EnemyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        EnemyNameText.text = CombatManager.EnemyFighter.FighterName;
        PlayerNameText.text = CombatManager.PlayerFighter.FighterName;
        PlayerMoveOneText.text = CombatManager.PlayerFighter.FightingMoves.First().MoveName;

        PlayerRenderer.sprite = CombatManager.PlayerSprite;
        EnemyRenderer.sprite = CombatManager.EnemySprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
