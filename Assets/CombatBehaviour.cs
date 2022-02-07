using Assets;
using UnityEngine;
using UnityEngine.UI;

public enum FightState {
    ChoseMove,
    Attack
}

public class CombatBehaviour : MonoBehaviour
{
    private bool InBetweenTurn = true;
    public FightState FightState = FightState.ChoseMove;

    public Text EnemyNameText;
    public Text PlayerNameText;

    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer EnemyRenderer;

    public HealthBarBehaviour PlayerHealthBar;
    public HealthBarBehaviour EnemyHealthBar;

    public FightingMovesBehaviour FightingMovesBehaviour;

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

    void Update()
    {
        switch (FightState)
        {
            case FightState.ChoseMove:
                FightingMovesBehaviour.gameObject.SetActive(true);
                return;
            case FightState.Attack:
                FightingMovesBehaviour.gameObject.SetActive(false);
                return;
            default:
                Debug.LogError("Unable to determine what state I'm in rn...");
                break;
        }
    }
}
