using Assets;
using Assets.Scripts.Extensions;
using Assets.Scripts.Fighters;
using Assets.Scripts.FightingMoves;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum FightState
{
    PlayerChoseMove,
    PlayerAttack,
    EnemyChoseMove,
    EnemyAttack,
    PlayerWon,
    PlayerLost
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

    public AudioSource AudioSource;

    private IFighter CurrentPlayerFighter;

    void Start()
    {
        CurrentPlayerFighter = SharedResources.PlayerFighters.First();

        EnemyNameText.text = SharedResources.EnemyFighter.FighterName;
        PlayerNameText.text = CurrentPlayerFighter.FighterName;

        var playerTexture = (Texture2D)Resources.Load(CurrentPlayerFighter.SpriteName);
        PlayerRenderer.sprite = playerTexture.GetFighterSprite();

        var enemyTexture = (Texture2D)Resources.Load(SharedResources.EnemyFighter.SpriteName);
        EnemyRenderer.sprite = enemyTexture.GetFighterSprite();

        AudioSource.clip = (AudioClip)Resources.Load(SharedResources.EnemyFighter.BattleSongName);
        AudioSource.Play();

        PlayerHealthBar.MaxHealth = CurrentPlayerFighter.MaxHp;
        PlayerHealthBar.CurrentHealth = CurrentPlayerFighter.CurrentHp;

        EnemyHealthBar.MaxHealth = SharedResources.EnemyFighter.MaxHp;
        EnemyHealthBar.CurrentHealth = SharedResources.EnemyFighter.CurrentHp;

        FightingMovesBehaviour.SetFightingMoves(CurrentPlayerFighter.FightingMoves.ToArray());
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
                    SharedResources.EnemyFighter.CurrentHp = SharedResources.EnemyFighter.CurrentHp - PlayerMove.Damage;
                    EnemyHealthBar.CurrentHealth = SharedResources.EnemyFighter.CurrentHp;
                }
                break;

            case FightState.PlayerAttack:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(true);
                StoryTextBehavior.SetDisplayText($"{ PlayerNameText.text} used {PlayerMove.MoveName}.", new Color(0.002f, 0.002f, 0.424f, 1));
                if (StoryTextBehavior.Clicked)
                {
                    StoryTextBehavior.Clicked = false;
                    StoryTextBehavior.gameObject.SetActive(false);
                    PlayerMove = null;
                    if (SharedResources.EnemyFighter.CurrentHp <= 0)
                    {
                        SetFightState(FightState.PlayerWon);
                    }
                    else
                    {
                        SetFightState(FightState.EnemyChoseMove);
                    }
                }
                break;

            case FightState.EnemyChoseMove:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(false);
                //Todo : Select a move from the fighting moves list
                EnemyMove = SharedResources.EnemyFighter.FightingMoves.First();
                CurrentPlayerFighter.CurrentHp = CurrentPlayerFighter.CurrentHp - EnemyMove.Damage;
                PlayerHealthBar.CurrentHealth = CurrentPlayerFighter.CurrentHp;
                SetFightState(FightState.EnemyAttack);
                break;

            case FightState.EnemyAttack:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(true);

                StoryTextBehavior.SetDisplayText($"{EnemyNameText.text} used {EnemyMove.MoveName}.", new Color(0.424f, 0.002f, 0.002f, 1));
                if (StoryTextBehavior.Clicked)
                {
                    StoryTextBehavior.Clicked = false;
                    StoryTextBehavior.gameObject.SetActive(false);
                    EnemyMove = null;
                    if (SharedResources.PlayerFighters.First().CurrentHp <= 0)
                    {
                        SetFightState(FightState.PlayerLost);
                    }
                    else
                    {
                        SetFightState(FightState.PlayerChoseMove);
                    }
                }
                break;

            case FightState.PlayerWon:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(true);
                StoryTextBehavior.SetDisplayText($"You defeated {EnemyNameText.text}!", new Color(0.002f, 0.424f, 0.002f, 1));
                if (StoryTextBehavior.Clicked)
                {
                    SceneManager.LoadScene(SharedResources.SceneToLoadAfter);
                }
                break;

            case FightState.PlayerLost:
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(true);
                StoryTextBehavior.SetDisplayText($"You lost against {EnemyNameText.text}!", new Color(0.424f, 0.002f, 0.002f, 1));
                if (StoryTextBehavior.Clicked)
                {
                    SceneManager.LoadScene("GameLost");
                }
                break;

            default:
                Debug.LogError("Unable to determine what state I'm in rn...");
                break;
        }
    }

    private void SetFightState(FightState newFightState)
    {
        FightState = newFightState;
    }

}
