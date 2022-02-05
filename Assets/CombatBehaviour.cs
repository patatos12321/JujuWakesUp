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
    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer EnemyRenderer;
    public HealthBarBehaviour PlayerHealthBar;
    public HealthBarBehaviour EnemyHealthBar;

    public FightingMovesBehaviour FightingMovesBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        EnemyNameText.text = CombatManager.EnemyFighter.FighterName;
        PlayerNameText.text = CombatManager.PlayerFighter.FighterName;

        PlayerRenderer.sprite = CombatManager.PlayerSprite;
        EnemyRenderer.sprite = CombatManager.EnemySprite;

        PlayerHealthBar.MaxHealth = CombatManager.PlayerFighter.MaxHp;
        PlayerHealthBar.CurrentHealth = CombatManager.PlayerFighter.CurrentHp;

        EnemyHealthBar.MaxHealth = CombatManager.EnemyFighter.MaxHp;
        EnemyHealthBar.CurrentHealth = CombatManager.EnemyFighter.CurrentHp;

        FightingMovesBehaviour.SetFightingMoves(CombatManager.PlayerFighter.FightingMoves.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
