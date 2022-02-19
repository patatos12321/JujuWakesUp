using System.Linq;
using Assets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum FightState {
    PlayerChoseMove,
    PlayerAttack,
    EnemyChoseMove,
    EnemyAttack
}

public class CombatBehaviour : MonoBehaviour
{
    public StoryTextBehavior StoryTextBehavior;
    public FightState FightState = FightState.PlayerChoseMove;

    public Text EnemyNameText;
    public Text PlayerNameText;

    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer EnemyRenderer;

    public HealthBarBehaviour PlayerHealthBar;
    public HealthBarBehaviour EnemyHealthBar;

    public FightingMovesBehaviour FightingMovesBehaviour;

    public IFightingMove PlayerMove;
    public IFightingMove EnemyMove;

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
            case FightState.PlayerChoseMove:
                StoryTextBehavior.gameObject.SetActive(false);
                FightingMovesBehaviour.gameObject.SetActive(true);
                if (PlayerMove != null)
                {
                    SetFightState(FightState.PlayerAttack);
                    CombatManager.EnemyFighter.CurrentHp = CombatManager.EnemyFighter.CurrentHp - PlayerMove.Damage;
                    EnemyHealthBar.CurrentHealth = CombatManager.EnemyFighter.CurrentHp;
                }
                break;
            case FightState.PlayerAttack:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(true);
                StoryTextBehavior.TextToDisplay = $"{PlayerNameText.text} used {PlayerMove.MoveName}.";
                if (StoryTextBehavior.Clicked)
                {
                    StoryTextBehavior.Clicked = false;
                    StoryTextBehavior.gameObject.SetActive(false);
                    PlayerMove = null;
                    SetFightState(FightState.EnemyChoseMove);
                }
                break;
            case FightState.EnemyChoseMove:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(false);
                //Todo : Select a move from the fighting moves list
                EnemyMove = CombatManager.EnemyFighter.FightingMoves.First();
                CombatManager.PlayerFighter.CurrentHp = CombatManager.PlayerFighter.CurrentHp - EnemyMove.Damage;
                PlayerHealthBar.CurrentHealth = CombatManager.PlayerFighter.CurrentHp;
                SetFightState(FightState.EnemyAttack);
                break;
            case FightState.EnemyAttack:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(true);
                StoryTextBehavior.TextToDisplay = $"{EnemyNameText.text} used {EnemyMove.MoveName}. Ouch!";
                if (StoryTextBehavior.Clicked)
                {
                    StoryTextBehavior.Clicked = false;
                    StoryTextBehavior.gameObject.SetActive(false);
                    EnemyMove = null;
                    SetFightState(FightState.PlayerChoseMove);
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

    private void SetFightState(FightState newFightState)
    {
        FightState = newFightState;
    }

}
