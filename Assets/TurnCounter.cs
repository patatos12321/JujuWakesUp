using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{
    public CombatBehaviour CombatBehaviour;
    public SingleTurnIndicator TurnIndicatorPrefab;

    private List<SingleTurnIndicator> turns;
    private int _nbTurnsInAdvance = 30;
    private int _nbPassedTurnsToKeep = 2;

    // Start is called before the first frame update
    void Start()
    {
        turns = new List<SingleTurnIndicator>();
        for (int i = 0; i < _nbTurnsInAdvance; i++)
        {
            var turnIndicator = Instantiate<SingleTurnIndicator>(TurnIndicatorPrefab, this.gameObject.transform);
            turnIndicator.TurnNumber = i;
            turns.Add(turnIndicator);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float _maxHeight = 4.25f;
        float _heighPerTurn = 0.5f;

        if (turns.Count < _nbTurnsInAdvance)
        {
            var turn = Instantiate<SingleTurnIndicator>(TurnIndicatorPrefab, this.gameObject.transform);
            turn.TurnNumber = turns.Max(t => t.TurnNumber) + 1;
            turns.Add(turn);
        }

        var turnsToDelete = new List<SingleTurnIndicator>();
        foreach (var turn in turns)
        {
            SetPlayerActive(turn);
            SetEnemyActive(turn);
            SetTurnActive(turn);

            if (turn.TurnNumber < CombatBehaviour.CurrentTurn - _nbPassedTurnsToKeep)
            {
                turnsToDelete.Add(turn);
                continue;
            }

            turn.transform.position = new Vector3(this.transform.position.x, _maxHeight - _heighPerTurn * (turn.TurnNumber - CombatBehaviour.CurrentTurn) + ((float)CombatBehaviour.CurrentNbFrameForTurn / (float)CombatBehaviour.NbFramePerTurn) * _heighPerTurn);
        }

        foreach (var turnToDelete in turnsToDelete)
        {
            turns.Remove(turnToDelete);
            DestroyImmediate(turnToDelete.gameObject);
        }
                
    }

    private void SetTurnActive(SingleTurnIndicator turn)
    {
        turn.IsTurnActive = turn.TurnNumber >= CombatBehaviour.CurrentTurn;
    }

    private void SetEnemyActive(SingleTurnIndicator turn)
    {
        if (turn.TurnNumber == CombatBehaviour.EnemyMoveEndTurn)
        {
            turn.IsEnemyActive = true;
        }
    }

    private void SetPlayerActive(SingleTurnIndicator turn)
    {
        if (turn.TurnNumber == CombatBehaviour.PlayerMoveEndTurn)
        {
            turn.IsPlayerActive = true;
        }
    }
}
