using Assets.Scripts.FightingMoves;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FightingMovesBehaviour : MonoBehaviour
{
    public CombatBehaviour CombatBehaviour;
    public IFightingMove[] FightingMoves;
    public Button[] MoveButtons;
    public Text[] MoveTexts;

    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < MoveButtons.Length; index++)
        {
            var test = index;
            MoveButtons[index].onClick.AddListener(() => TaskOnClick(test));
        }
    }

    public void SetFightingMoves(IFightingMove[] fightingMoves)
    {
        FightingMoves = fightingMoves;
        for (int index = 0; index < MoveButtons.Length; index++)
        {
            if (fightingMoves.Length < index + 1)
            {
                MoveButtons[index].gameObject.SetActive(false);
            }
            else 
            {
                MoveButtons[index].gameObject.SetActive(true);
                MoveTexts[index].text = FightingMoves[index].MoveName + " - " + FightingMoves[index].Duration;
            }
        }
    }

    void TaskOnClick(int moveIndex)
    {
        CombatBehaviour.PlayerMove = FightingMoves[moveIndex];
    }
}
