using Assets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum FightState {
    ChoseMove,
    Attack
}

public class CombatBehaviour : MonoBehaviour
{
    public StoryTextBehavior StoryTextBehavior;
    public FightState FightState = FightState.ChoseMove;

    public Text EnemyNameText;
    public Text PlayerNameText;

    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer EnemyRenderer;

    public HealthBarBehaviour PlayerHealthBar;
    public HealthBarBehaviour EnemyHealthBar;

    public FightingMovesBehaviour FightingMovesBehaviour;

    public IFightingMove PlayerMove;

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
                StoryTextBehavior.gameObject.SetActive(false);
                FightingMovesBehaviour.gameObject.SetActive(true);
                if (PlayerMove != null)
                {
                    FightState = FightState.Attack;
                    CombatManager.EnemyFighter.CurrentHp = CombatManager.EnemyFighter.CurrentHp - PlayerMove.Damage;
                    EnemyHealthBar.CurrentHealth = CombatManager.EnemyFighter.CurrentHp;
                }
                break;
            case FightState.Attack:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(true);
                StoryTextBehavior.TextToDisplay = $"{PlayerNameText.text} used {PlayerMove.MoveName}.";
                if (StoryTextBehavior.Clicked)
                {
                    StoryTextBehavior.Clicked = false;
                    StoryTextBehavior.gameObject.SetActive(false);
                    PlayerMove = null;
                    FightState = FightState.ChoseMove;
                }
                break;
            default:
                Debug.LogError("Unable to determine what state I'm in rn...");
                break;
        }

        if (CombatManager.EnemyFighter.CurrentHp <= 0)
        {
            SceneManager.LoadScene(CombatManager.SceneToLoadAfterCombat);
        }
    }
}
