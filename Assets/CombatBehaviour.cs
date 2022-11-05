using Assets;
using Assets.Scripts.Extensions;
using Assets.Scripts.Fighters;
using Assets.Scripts.FightingMoves;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum FightState
{
    PlayerChoseMove,
    PlayerAttack,
    PlayerChoseFighter,
    EnemyChoseMove,
    EnemyAttack,
    PlayerWon,
    PlayerLost
}

public class CombatBehaviour : MonoBehaviour
{
    public int CurrentTurn = 0;
    public int NbFramePerTurn = 120;
    public int CurrentNbFrameForTurn = 0;
    private bool CombatPaused = false;

    public StoryTextBehavior StoryTextBehavior;
    public FightState FightState = FightState.PlayerChoseMove;

    public Text EnemyNameText;
    public Text PlayerNameText;

    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer EnemyRenderer;

    public HealthBarBehaviour PlayerHealthBar;
    public HealthBarBehaviour EnemyHealthBar;

    public FightingMovesBehaviour FightingMovesBehaviour;
    public TeamViewerBehavior TeamViewerBehavior;

    public IFightingMove PlayerMove;
    public int PlayerMoveEndTurn;
    public IFightingMove EnemyMove;
    public int EnemyMoveEndTurn;

    public AudioSource AudioSource;

    private IFighter CurrentPlayerFighter;

    void Start()
    {
        CurrentPlayerFighter = SharedResources.PlayerFighters.Where(p => p.IsAlive()).First();
        ResetPlayerInfo();

        var enemyTexture = (Texture2D)Resources.Load(SharedResources.EnemyFighter.SpriteName);
        EnemyRenderer.sprite = enemyTexture.GetFighterSprite();

        AudioSource.clip = (AudioClip)Resources.Load(SharedResources.EnemyFighter.BattleSongName);
        AudioSource.Play();

        EnemyNameText.text = SharedResources.EnemyFighter.FighterName;
        EnemyHealthBar.MaxHealth = SharedResources.EnemyFighter.MaxHp;
        EnemyHealthBar.CurrentHealth = SharedResources.EnemyFighter.CurrentHp;

        TeamViewerBehavior.gameObject.SetActive(false);
    }

    void Update()
    {
        if (CurrentTurn < PlayerMoveEndTurn && CurrentTurn < EnemyMoveEndTurn && !CombatPaused)
        {
            CurrentNbFrameForTurn++;
            if (CurrentNbFrameForTurn > NbFramePerTurn)
            {
                CurrentTurn++;
                CurrentNbFrameForTurn = 0;
            }
        }


        switch (FightState)
        {
            case FightState.PlayerChoseMove:
                if (PlayerMoveEndTurn > CurrentTurn)
                    return;

                StoryTextBehavior.gameObject.SetActive(false);
                FightingMovesBehaviour.gameObject.SetActive(true);
                if (PlayerMove != null)
                {
                    CombatPaused = true;
                    SetFightState(FightState.PlayerAttack);
                    EnemyHealthBar.CurrentHealth = SharedResources.EnemyFighter.CurrentHp = Math.Max(0, SharedResources.EnemyFighter.CurrentHp - PlayerMove.Damage);
                    PlayerMoveEndTurn = CurrentTurn + PlayerMove.Duration;
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
                    if (EnemyIsDead() || SharedResources.PlayerFighters.Where(pf => pf.IsAlive()).Count() == 1)
                    {
                        SetNextFighterChoseMoveState();
                        CombatPaused = false;
                    }
                    else
                    {
                        SetFightState(FightState.PlayerChoseFighter);
                    }
                    PlayerMove = null;
                }
                break;

            case FightState.PlayerChoseFighter:
                CombatPaused = true;

                TeamViewerBehavior.ResetFighters();
                TeamViewerBehavior.gameObject.SetActive(true);

                StoryTextBehavior.gameObject.SetActive(true);
                StoryTextBehavior.SetDisplayText($"*Chose your next fighter!*", new Color(0.002f, 0.002f, 0.424f, 1));

                if (TeamViewerBehavior.SelectedFighter != null)
                {
                    StoryTextBehavior.Clicked = false;
                    StoryTextBehavior.gameObject.SetActive(false);
                    CurrentPlayerFighter = TeamViewerBehavior.SelectedFighter;
                    
                    TeamViewerBehavior.gameObject.SetActive(false);
                    TeamViewerBehavior.UnselectFighter();

                    ResetPlayerInfo();
                    SetNextFighterChoseMoveState();
                    CombatPaused = false;
                }
                break;

            case FightState.EnemyChoseMove:
                if (EnemyMoveEndTurn > CurrentTurn)
                    return;

                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(false);
                //Todo : Select a move from the fighting moves list
                EnemyMove = SharedResources.EnemyFighter.FightingMoves.First();
                PlayerHealthBar.CurrentHealth = CurrentPlayerFighter.CurrentHp = Math.Max(0, CurrentPlayerFighter.CurrentHp - EnemyMove.Damage);
                SetFightState(FightState.EnemyAttack);
                EnemyMoveEndTurn = CurrentTurn + EnemyMove.Duration;
                CombatPaused = true;
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

                    SetNextFighterChoseMoveState();
                    CombatPaused = false;
                }
                break;

            case FightState.PlayerWon:
                CombatPaused = true;
                FightingMovesBehaviour.gameObject.SetActive(false);
                StoryTextBehavior.gameObject.SetActive(true);
                StoryTextBehavior.SetDisplayText($"You defeated {EnemyNameText.text}!", new Color(0.002f, 0.424f, 0.002f, 1));
                if (StoryTextBehavior.Clicked)
                {
                    SceneManager.LoadScene(SharedResources.SceneToLoadAfter);
                }
                break;

            case FightState.PlayerLost:
                CombatPaused = true;
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

    private void SetNextFighterChoseMoveState()
    {
        if (CurrentPlayerFighter.CurrentHp <= 0)
        {
            if (SharedResources.PlayerFighters.Any(p => p.IsAlive()))
            {
                SetFightState(FightState.PlayerChoseFighter);
            }
            else
            {
                SetFightState(FightState.PlayerLost);
            }
        }
        else if (EnemyIsDead())
        {
            SetFightState(FightState.PlayerWon);
        }
        else if (PlayerMoveEndTurn <= EnemyMoveEndTurn)
        {
            SetFightState(FightState.PlayerChoseMove);
        }
        else
        {
            SetFightState(FightState.EnemyChoseMove);
        }
    }

    private static bool EnemyIsDead()
    {
        return SharedResources.EnemyFighter.CurrentHp <= 0;
    }

    private void SetFightState(FightState newFightState)
    {
        FightState = newFightState;
    }

    private void ResetPlayerInfo()
    {
        PlayerNameText.text = CurrentPlayerFighter.FighterName;
        PlayerHealthBar.MaxHealth = CurrentPlayerFighter.MaxHp;
        PlayerHealthBar.CurrentHealth = CurrentPlayerFighter.CurrentHp;
        FightingMovesBehaviour.SetFightingMoves(CurrentPlayerFighter.FightingMoves.ToArray());

        var playerTexture = (Texture2D)Resources.Load(CurrentPlayerFighter.SpriteName);
        PlayerRenderer.sprite = playerTexture.GetFighterSprite();
    }

}
